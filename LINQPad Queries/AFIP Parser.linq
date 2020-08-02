<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
  <Namespace>NPOI.HSSF.UserModel</Namespace>
</Query>

void Main()
{	
	var models = new List<AFIPRawModel>();
	
	var nombre_Archivo = $"VENTAS.TXT";
	
	var nombre_Excel = "Ventas Generadas";
	
	foreach (var line in OpenTxtFromDesktop(nombre_Archivo))
		models.Add(InputToAFIPModel(line));	

	models.All(m => m.IsValidated).Dump("Is Validated: ");

	models.Select(d => d.DTO.MontoFactura).Sum().Dump("Monto Final:");

	models.Dump();
	
	var matrix = new List<string[]>();
	
	matrix.Add(AFIPDTO.Nombres);
	
	matrix.AddRange(models.Select(m => m.DTO.Rows).ToArray());

	var fecha = models.First().DTO.Fecha;

	GenerateSheet(matrix, $"{nombre_Excel} { fecha?.Month.ToString() } - { fecha?.Year }.xlsx");
}

#region Excel

public static void GenerateSheet(IEnumerable<IEnumerable<string>> matrix, string path)
{
	var workbook = new HSSFWorkbook();
	var sheet = workbook.CreateSheet();
	int contRow = 0;
	int contCell = 0;

	foreach (var line in matrix)
	{
		var row = sheet.CreateRow(contRow);
		contRow++;
		contCell = 0;

		foreach (var cell in line)
		{
			var auxcell = row.CreateCell(contCell);
			auxcell.SetCellValue(cell);
			contCell++;
		}
	}

	Enumerable.Range(0, sheet.GetRow(0).PhysicalNumberOfCells)
			  .ToList()
			  .ForEach(i => { sheet.AutoSizeColumn(i); GC.Collect(); });

	using (var xfile = new FileStream(DesktopPath(path), FileMode.Create, System.IO.FileAccess.Write))
	{
		workbook.Write(xfile);
	}

	"Workbook generated successfully".Dump();
}

#endregion

#region Utils

static string Concat<T>(IEnumerable<T> arr) => arr.Aggregate(new StringBuilder(), (acum, s) => acum.Append(s)).ToString();

static (string taken, string left) Split(string s, int index) => (Concat(s.ToCharArray().Take(index)), Concat(s.ToCharArray().Skip(index)));

static string DesktopPath(string path) => $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/{path}";

static IEnumerable<string> OpenTxtFromDesktop(string path)
{
	var fullpath = DesktopPath(path);

	if (!File.Exists(fullpath))
		throw new FileNotFoundException($"El archivo {path} no se encuentra en el escritorio!");

	string line;
	using (var streamReader = new StreamReader(new FileStream(fullpath, FileMode.Open, FileAccess.Read), Encoding.UTF8))
		while ((line = streamReader.ReadLine()) != null)
			yield return line;
}

#endregion

#region AFIP Related

static AFIPRawModel InputToAFIPModel(string input)
{
	var model = new AFIPRawModel();
	
	var acum = string.Empty;
	
	(model.Año, acum) = Split(input, 4); 
	
	(model.Mes, acum) = Split(acum, 2);
	
	(model.Dia, acum) = Split(acum, 2);
	
	(model.TipoDeComprobante, acum) = Split(acum, 3); 
	
	(model.PuntoDeVenta, acum) = Split(acum, 5);
	
	(model.NumeroComprobanteDesde, acum) = Split(acum, 20);

	(model.NumeroComprobanteHasta, acum) = Split(acum, 20);

	(model.CodigoDocumento, acum) = Split(acum, 2);
	
	(model.DataAleatoria, acum) = Split(acum, 50);
	
	(model.MontoFactura, acum) = Split(acum, 15);
	
	model.DataAleatoria2 =  acum;
	
	model.Validate(input);
	
	return model;
}

class AFIPRawModel
{
	#region To DTO
	
	public AFIPDTO DTO => ToDto();

	AFIPDTO ToDto()
	{
		var dto = new AFIPDTO();

		try
		{
			int Int(string s) => Convert.ToInt32(s);

			dto.Fecha = new DateTime(Int(Año), Int(Mes), Int(Dia));
		}
		catch { }

		if (int.TryParse(TipoDeComprobante, out int tipoComprobante))
			dto.TipoDeComprobante = tipoComprobante;

		if (int.TryParse(PuntoDeVenta, out int puntoDeVenta))
			dto.PuntoDeVenta = puntoDeVenta;

		if (int.TryParse(NumeroComprobanteDesde, out int numeroComprobanteDesde))
			dto.NumeroComprobanteDesde = numeroComprobanteDesde;

		if (int.TryParse(NumeroComprobanteHasta, out int numeroComprobanteHasta))
			dto.NumeroComprobanteHasta = numeroComprobanteHasta;

		if (int.TryParse(CodigoDocumento, out int codigoDocumento))
			dto.CodigoDocumento = codigoDocumento;

		dto.DataAleatoria = DataAleatoria;

		var size = MontoFactura.Count();

		(string monto, string monedas) = Split(MontoFactura, size - 2);

		var style = NumberStyles.AllowDecimalPoint;
		var provider = new CultureInfo("en-US");
		
		if (decimal.TryParse($"{monto}.{monedas}", style, provider, out decimal montoFactura))
			dto.MontoFactura = montoFactura;

		dto.DataAleatoria2 = DataAleatoria2;

		return dto;
	}

	#endregion

    #region Validation

	public string InputValue() => Concat(GetType().GetProperties().Where(p => p.PropertyType == typeof(string)).Select(p => p.GetValue(this)));

	public bool Validate(string s) => IsValidated = s == InputValue();

	public bool IsValidated { get; private set; }

	#endregion
	
	#region Propiedades

	public string Año { get; set; }
	
	public string Mes { get; set; }
	
	public string Dia { get; set; }
	
	public string TipoDeComprobante { get; set; }
	
	public string PuntoDeVenta { get; set;}
	
	public string NumeroComprobanteDesde { get; set; }
	
	public string NumeroComprobanteHasta { get; set; }
	
	public string CodigoDocumento { get; set; }
	
	public string DataAleatoria { get; set; }
	
	public string MontoFactura { get; set; }
	
	public string DataAleatoria2 { get; set; }

	#endregion
}

class AFIPDTO
{
	public DateTime? Fecha { get; set; }

	public int? TipoDeComprobante { get; set; }

	public int? PuntoDeVenta { get; set; }

	public int? NumeroComprobanteDesde { get; set; }

	public int? NumeroComprobanteHasta { get; set; }

	public int? CodigoDocumento { get; set; }

	public string DataAleatoria { get; set; }

	public decimal? MontoFactura { get; set; }

	public string DataAleatoria2 { get; set; }
	
	public string [] Rows => new string []
	{
		Fecha.ToString(),
		TipoDeComprobante.ToString(),
		PuntoDeVenta.ToString(),
		NumeroComprobanteDesde.ToString(),
		NumeroComprobanteHasta.ToString(),
		CodigoDocumento.ToString(),
		DataAleatoria.ToString(),
		MontoFactura.ToString(),
		DataAleatoria2.ToString()
	};
	
	public static string [] Nombres => new string []
	{
		"Fecha",
		"TipoDeComprobante",
		"PuntoDeVenta",
		"NumeroComprobanteDesde",
		"NumeroComprobanteHasta",
		"CodigoDocumento",
		"DataAleatoria",
		"MontoFactura",
		"DataAleatoria2"
	};
}

#endregion


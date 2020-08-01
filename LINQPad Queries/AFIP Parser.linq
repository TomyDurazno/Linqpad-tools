<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{	
	var models = new List<AFIPRawModel>();
	
	var nombre = $"VENTAS.TXT";
	
	foreach (var line in OpenTxtFromDesktop(nombre))
	{
		models.Add(InputToAFIPModel(line));
	}

	models.Select(m => m.ToDTO.MontoFactura).Sum().Dump("Monto Final:");

	models.Dump();
}

public static IEnumerable<string> OpenTxtFromDesktop(string path)
{
	string line;
	var fileStream = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/{path}", FileMode.Open, FileAccess.Read);

	using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
		while ((line = streamReader.ReadLine()) != null)
			yield return line;
}

public static AFIPRawModel InputToAFIPModel(string input)
{
	var model = new AFIPRawModel();
	
	(string año,string without_y) = Split(input, 4); 
	
	model.Año = año;
	
	(string mes, string without_yandm) = Split(without_y, 2);
	
	model.Mes = mes;
	
	(string dia, string left) = Split(without_yandm, 2);
	
	model.Dia = dia;
	
	(string comprobante, string left2) = Split(left, 3); 
	
	model.TipoDeComprobante = comprobante;
	
	(string pdv, string left3) = Split(left2, 5);
	
	model.PuntoDeVenta = pdv;
	
	(string ncd, string left4) = Split(left3, 20);
	
	model.NumeroComprobanteDesde = ncd;

	(string nca, string left5) = Split(left4, 20);

	model.NumeroComprobanteHasta = nca;

	(string codigoDoc, string left6) = Split(left5, 2);

	model.CodigoDocumento = codigoDoc;
	
	(string dataAl, string left7) = Split(left6, 50);

	model.DataAleatoria = dataAl;
	
	(string montoFactura, string left8) = Split(left7, 15);

	model.MontoFactura = montoFactura;
	
	model.DataAleatoria2 = left8;	
	
	model.Validate(input);
	
	return model;
}

public static (string taken, string left) Split(string s, int index)
{
	var taken = s.ToCharArray().Take(index).Aggregate (new StringBuilder(), (x, y) => x.Append(y)).ToString();	
	
	var left = s.ToCharArray().Skip(index).Aggregate (new StringBuilder(), (x, y) => x.Append(y)).ToString();	
	
	return (taken, left);
}

public class AFIPRawModel
{
	#region To DTO
	
	public AFIPDTO ToDTO => ToDto();

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
		var provider = CultureInfo.CurrentCulture;

		if (decimal.TryParse($"{monto}.{monedas}", style, provider, out decimal montoFactura))
			dto.MontoFactura = montoFactura;

		dto.DataAleatoria2 = DataAleatoria2;

		return dto;
	}

	#endregion

	#region Propiedades

	public bool Validate(string s) => IsValidated = s == RawInput();

	public bool IsValidated { get; private set; }

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
	
	public string RawInput()
	{
		return new []
		{
			Año,
			Mes,
			Dia,			
			TipoDeComprobante,
			PuntoDeVenta,
			NumeroComprobanteDesde,
			NumeroComprobanteHasta,
			CodigoDocumento,
			DataAleatoria,
			MontoFactura,
			DataAleatoria2
		}.Aggregate (new StringBuilder(), (x, y) => x.Append(y)).ToString();
	}	
}

public class AFIPDTO
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
}


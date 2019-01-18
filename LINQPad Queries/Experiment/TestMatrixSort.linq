<Query Kind="Program" />

void Main()
{
	var campos =  new string []{"Calle", "Código Postal", "CUIT o CUIL", "Depto", "Email", "Localidad", "N° de Puerta", "Nº Ing. Brutos", "Piso", "Provincia", "Telefono (número)", "Telefono (prefijo)", "Telefono (sufijo)", "Tipo Ing. Brutos", "Torre"};
	campos.Select((x, i) => new { Index = i, Value = x })
        .GroupBy(x => x.Index / 3)
        .Select(x => x.Select(v => v.Value).ToList())
        .ToList()
		.Dump();
	
}

// Define other methods and classes here

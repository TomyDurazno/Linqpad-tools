<Query Kind="Program" />

void Main()
{
	var input = "[{\"id\":29,\"name\":\"AGC-\\u003eDGFyC-\\u003eActividad Nocturna\"}],29,System.Collections.Generic.List`1[LIZA.Dominio.Entidades.Grupo]";
	var result = RegexBorrarCorchetes(input);
	result.Dump();
}

public string RegexBorrarCorchetes(string input)
{
	var output = Regex.Replace(input, @" ?\[.*?\]", string.Empty);
	return output;
}

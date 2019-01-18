<Query Kind="Program" />

void Main()
{
	var collect = new System.Collections.Specialized.NameValueCollection()
	{
		{ "green", "verde" }
	};
	
	collect.Add("red","rojo");
	collect.Add("blue","azul");
	collect.Add("yellow","amarillo");
	
	collect.AllKeys
		   .ToDictionary(x => x, x => collect[x])
		   .Dump();
}


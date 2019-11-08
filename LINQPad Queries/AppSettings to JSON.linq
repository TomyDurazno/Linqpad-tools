<Query Kind="Program">
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{	
	var properties = "app.txt"
						.Pipe(
							MyUtils.ReadTxtFromDesktop,
							string.Concat,
							XDocument.Parse, 
							n => n.ToXmlDocument(),
							n => n.SelectSingleNode("appSettings").ChildNodes.GetNodes(),
							n => n.Select(x => new { 		//Returns an anonymous object! 
								Key = x.Attributes["key"].InnerText,
								Value = x.Attributes["value"].InnerText
							}),
							d => d.Select(a => $"public string { a.Key}  = { a.Value };"));
							
	
	//Compiler error, because we are passing 'IEnumerable<string>' as argument
	properties.Dump();
}

// Define other methods and classes here
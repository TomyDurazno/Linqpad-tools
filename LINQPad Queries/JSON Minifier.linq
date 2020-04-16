<Query Kind="Program">
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

#load "MultilineIO"

void Main()
{	
	var input = new MultilineIO();
	
	input.Create(s => JToken.Parse(s).ToString(Newtonsoft.Json.Formatting.None));
}
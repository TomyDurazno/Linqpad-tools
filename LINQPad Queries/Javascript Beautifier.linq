<Query Kind="Program">
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System.Web</Namespace>
  <RemoveNamespace>System.Xml</RemoveNamespace>
</Query>

#load "MultilineIO"
void Main()
{
	var input = new MultilineIO();

	input.Create(i => JToken.Parse(i).ToString(Newtonsoft.Json.Formatting.Indented).Dump());
}

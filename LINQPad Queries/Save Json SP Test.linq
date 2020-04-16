<Query Kind="Program">
  <Connection>
    <ID>9fa3dc2d-593a-4ad4-9bfe-ef2f57705a68</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Power_Pause</Database>
  </Connection>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <RemoveNamespace>System.Xml</RemoveNamespace>
</Query>

#load "MultilineIO"
async Task Main()
{
	var input = new MultilineIO();

	input.Create(s =>
	{
		s.Pipe(
			JToken.Parse, 
			t => t.ToString(Formatting.None), 
			m => SaveJSON_TEST(m, Guid.NewGuid(), "Package Name 1", null))
		.Dump();

		s.Dump();
	});
}
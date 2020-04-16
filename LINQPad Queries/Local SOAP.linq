<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var xml = MyUtils.ReadTxtFromDesktop("request.xml")
					 .Concatenate()
					 .Mute(()=> new XmlDocument(), (s, doc) => doc.LoadXml(s)); 
					 //.Pipe(s => { var doc = new XmlDocument(); doc.LoadXml(s); return doc; });
	
	xml.Dump();
	var result = await MyUtils.ExecuteXmlPostRequestAsync("http://localhost:1580/QuikFormsEngine.asmx", xml);
	
	result.Dump();
}
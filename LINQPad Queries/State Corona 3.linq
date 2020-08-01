<Query Kind="Program">
  <Reference Relative="..\..\..\source\repos\CoronaManager\CoronaManager\bin\Debug\netcoreapp3.0\CoronaManager.dll">C:\Users\tcordara\source\repos\CoronaManager\CoronaManager\bin\Debug\netcoreapp3.0\CoronaManager.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>CoronaManager</Namespace>
</Query>

async Task Main()
{
	//MyUtils.ReadTxtFromDesktop("page.txt").Concatenate().Trim().Dump();
	
	var result = await MyUtils.Http.Get("https://corona.lmao.ninja/countries");
	
	var paises = result.Content.Pipe(JArray.Parse, s => s.ToObject<RootObject[]>());
	
	paises.Dump();
}

public class CountryInfo
{
	public string iso2 { get; set; }
	public string iso3 { get; set; }
	public object _id { get; set; }
	public double lat { get; set; }
	public double @long { get; set; }
	public string flag { get; set; }
}

public class RootObject
{
	public string country { get; set; }
	public CountryInfo countryInfo { get; set; }
	public int cases { get; set; }
	public int todayCases { get; set; }
	public int deaths { get; set; }
	public int todayDeaths { get; set; }
	public int recovered { get; set; }
	public int active { get; set; }
	public int critical { get; set; }
	public int casesPerOneMillion { get; set; }
}
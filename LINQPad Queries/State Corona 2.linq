<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

async Task Main()
{	
	var state = await GetState();
	
	state.Dump();
}

public class CoronaObj
{
	public string country { get; set; }
	public int cases { get; set; }
	public int todayCases { get; set; }
	public int deaths { get; set; }
	public int todayDeaths { get; set; }
	public int recovered { get; set; }
	public int active { get; set; }
	public int critical { get; set; }
	public int casesPerOneMillion { get; set; }
}

public async Task<List<CoronaObj>> GetState()
{
	List<CoronaObj> Transform(List<CoronaObj> lista)
	{
		return lista.OrderByDescending(l => l.deaths).ToList();
	}
	
	var result = await MyUtils.Http.Get(string.Empty, "https://corona.lmao.ninja/countries", null);

	return result.Content.Pipe(JArray.Parse, a => a.ToObject<List<CoronaObj>>(), Transform);				 
}
<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Client.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Activation.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <NuGetReference>RestSharp</NuGetReference>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>RestSharp</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Web</Namespace>
</Query>

async Task Main()
{
	var milliseconds = new TimeSpan(0, 0, 15).TotalMilliseconds.Pipe(Convert.ToInt32);

	var stop = new TimeSpan(18, 30, 0);

	var fileName = "DolarHoy.txt";

	bool writeToTxt = false;

	void WriteTxt(string s){ if (writeToTxt) MyUtils.WriteTxtToDesktop(s.Pipe(a => new[] { a }), fileName); }

	void Cotización() => Cotizar().Then(t => t.ToString().Dump().Mutate(WriteTxt)).Wait();

	//Remember: ctrl + shift + f5 for 'Query Process Unload'
	await MyUtils.SetIntervalAsync(milliseconds, stop, Cotización);		
}

public async Task<DolarServiceResponse> Cotizar()
{
	var clienteBanco = new RestClient(new Uri("http://www.bancoprovincia.com.ar/"));

	var request = new RestRequest("Principal/Dolar", Method.GET).AddHeader("Accept", "application/json");

	return (await clienteBanco.ExecuteAsync(request))					
					.Pipe(t => t.Content, JArray.Parse, j => j.ToObject<string[]>(), r => new DolarServiceResponse(r));	
}

public class DolarServiceResponse
{
	public string Compra { get; set; }
	public string Venta { get; set; }
	public string Actualizado { get; set; }
	
	public DolarServiceResponse(string[] response)
	{
		Compra = string.Format("Compra: {0}", response[0]);	
		Venta = string.Format("Venta {0}", response[1]);	
		Actualizado = response[2];
	}

	public override string ToString()
	{
		return string.Join(", ", new string[] { Compra, Venta, Actualizado });
	}
}

//https://stackoverflow.com/questions/24791493/restart-a-completed-task
//No se puede restart una Task, que es un reference type MIRA VOIS
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
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
  <Namespace>RestSharp</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

async Task Main()
{
	var milliseconds = new TimeSpan(0, 0, 15).TotalMilliseconds.Project(Convert.ToInt32);
	
	var stop = new TimeSpan(18, 30, 0);	
	
	var fileName = "DolarHoy.txt";
	
	Action action = () => Cotizar().ContinueWith(t => MyUtils.WriteTxtToDesktop(t.Result.ToString().AsArray(), fileName))
								   .Wait();

	//Remember: ctrl + shift + f5 for 'Query Process Unload'
	await MyUtils.SetIntervalAsync(milliseconds, stop, action);				
}

public async Task<DolarServiceResponse> Cotizar()
{
	var clienteBanco = new RestClient(new Uri("http://www.bancoprovincia.com.ar/"));

	var request = new RestRequest("Principal/Dolar", Method.GET).AddHeader("Accept", "application/json");

	//request.AddHeader("Accept", "application/json");

	var response = await clienteBanco.ExecuteTaskAsync(request);

	return JArray.Parse(response.Content).ToObject<string[]>().Project(r => new DolarServiceResponse(r));
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
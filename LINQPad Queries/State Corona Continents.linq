<Query Kind="Program">
  <Reference Relative="..\..\..\source\repos\CoronaManager\CoronaManager\bin\Debug\netcoreapp3.0\CoronaManager.dll">C:\Users\tcordara\source\repos\CoronaManager\CoronaManager\bin\Debug\netcoreapp3.0\CoronaManager.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>CoronaManager.Services</Namespace>
</Query>

async Task Main()
{
	var path = @"C:\Users\tcordara\source\repos\CoronaManager\CoronaManager\Data\Continents\";
	
	var service = new CoronaNinjaAPIService(path);
	
	var result = await service.AmountByContinent();
	
	result.Dump();
}

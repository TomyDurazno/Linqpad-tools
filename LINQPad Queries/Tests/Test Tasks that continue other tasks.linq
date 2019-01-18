<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	await Task.Delay(new TimeSpan(0, 0, 3))
			  .ContinueWith(t => t.Id.Dump())
			  .ContinueWith(t => t.Id.Dump())
			  .ContinueWith(t => t.Id.Dump());
	
	await Task.Delay(new TimeSpan(0, 0, 3)).ContinueWith(t => t.Id.Dump());
}


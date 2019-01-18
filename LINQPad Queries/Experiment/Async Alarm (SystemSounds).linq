<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	await MyUtils.SetTimeOutAsync(1000, new TimeSpan(19,12,00), System.Media.SystemSounds.Exclamation.Play);
}

// Define other methods and classes here
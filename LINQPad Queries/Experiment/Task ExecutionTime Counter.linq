<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{	
	var t1 = TakeTime(2000).ContinueWith(x => "HeyyYo".Dump());
	
	var tasks = new[] { TakeTime(6500), TakeTime(2500), TakeTime(4000) }.Select(t => TaskCounter.Run(t));
	
	var results = await Task.WhenAll(tasks);
	
	results.Dump();
}

public class TimedResult<T>
{
	public TimeSpan Elapsed { get; set; }
	public T Result { get; set; }	
}

public static class TaskCounter
{
	public static async Task<TimedResult<T>> Run<T>(Task<T> task)
	{
		var stopwatch = new Stopwatch();
		stopwatch.Start();
		var result = await task;
		stopwatch.Stop();
		
		return new TimedResult<T>()
		{
			Elapsed = stopwatch.Elapsed,
			Result = result
		};
	}
}

public async Task<string> TakeTime(int milliseconds)
{
	await Task.Delay(milliseconds);
	return "Done!";
} 

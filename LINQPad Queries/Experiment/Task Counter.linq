<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	await TaskCounter.Run2(TwoSecs(),
	() => { 
		var stop = new Stopwatch(); 
		stop.Start(); 
		return stop;
	},
	(watch, result) => {
		watch.Stop();
		return new 
		{
			Elapsed = watch.Elapsed,
			Result = result
		};
	});
}

public static async Task<string> TwoSecs()
{
	await Task.Delay(2000);
	return "Named";
}

public static class TaskCounter
{
	public static async Task<TimedResult<T>> Run<T>(string name, Task<T> task)
	{
		var stopwatch = new Stopwatch();
		stopwatch.Start();
		var result = await task;
		stopwatch.Stop();

		return new TimedResult<T>()
		{
			Elapsed = stopwatch.Elapsed,
			Result = result,
			Name = name
		};
	}

	public static async Task<S> Run2<T,K,S>(Task<T> task, Func<K> preEval, Func<K, T, S> postEval)
	{
		var k = preEval();

		var result = await task;
		return postEval(k, result);
	}

	public class TimedResult<T>
	{
		public TimeSpan Elapsed { get; set; }
		public T Result { get; set; }

		public string Name { get; set; }
	}
}
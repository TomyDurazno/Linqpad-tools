<Query Kind="Program" />

void Main()
{
	var counter = new TimeCounter(new TimeSpan(0,0,2));

	counter.Call(() => 
	{
		Thread.Sleep(2000);
	});
	
	counter.PassedSpan.Dump();
	
	counter.Elapsed.Dump();
}

public class TimeCounter
{
	private TimeSpan maxSpan;
	private Stopwatch stopwatch;
	private TimeSpan elapsedSpan;
	private bool passedSpan;

	/// <summary> Class used to measure the execution time of a function
	/// </summary>
	/// <param name="maxMillisecondsSpan"> Max amount span (in milliseconds) </param>
	public TimeCounter(TimeSpan span)
	{
		maxSpan = span;
		stopwatch = new Stopwatch();
	}

	public T Call<T>(Func<T> func)
	{
		stopwatch.Reset();
		stopwatch.Start();
		T result = func();
		stopwatch.Stop();
		elapsedSpan = stopwatch.Elapsed;
		passedSpan = elapsedSpan > maxSpan;
		return result;
	}

	public void Call(Action action)
	{
		stopwatch.Reset();
		stopwatch.Start();
		action();
		stopwatch.Stop();
		elapsedSpan = stopwatch.Elapsed;
		passedSpan = elapsedSpan > maxSpan;
	}


	public bool PassedSpan
	{
		get
		{
			return passedSpan;
		}
	}
	public TimeSpan Elapsed
	{
		get
		{
			return elapsedSpan;
		}
	}
}
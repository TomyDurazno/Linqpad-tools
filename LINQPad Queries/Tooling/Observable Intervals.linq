<Query Kind="Program">
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
</Query>

void Main()
{
	Observable.Interval(TimeSpan.FromSeconds(2), Scheduler.Default)
			  .Subscribe(o => MyUtils.WriteTxtToDesktop(new[] { o.ToString()}, "ticks.txt", true));
}

// Define other methods and classes here
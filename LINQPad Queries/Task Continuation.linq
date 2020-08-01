<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>LINQPad.FSharpExtensions</Namespace>
</Query>

async Task Main()
{
	async Task<List<int>> Times()
	{
		List<int> Continuation (Task<List<int>> t) { t.Result.Add(Thread.CurrentThread.ManagedThreadId); return t.Result; }
		
		return await
		Task.Delay(new TimeSpan(3000))
			.ContinueWith(t => new int[] { }.ToList())
			.ContinueWith(Continuation)
			.ContinueWith(Continuation)
			.ContinueWith(Continuation)
			.ContinueWith(Continuation)
			.ContinueWith(Continuation)
			.ContinueWith(t => t.Result);
	}

	var result = await Enumerable.Range(0, 100)
								 .Select(pe => Times())
								 .Pipe(Task.WhenAll);
	
	result.Where(r => r.Distinct().Count() > 1).Dump();
}


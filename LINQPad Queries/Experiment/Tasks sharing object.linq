<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var summer = new Summer();
	
	var tasks = Enumerable.Range(0, 5).Select(e => new Task(() => summer.Sum())).ToList();
	
	tasks.ForEach(t => t.Start());
	
	await Task.WhenAll(tasks);
	
	summer.Dump();
}

public class Summer
{
	public int Number { get; set; }
	
	public Summer()
	{
		Number = 0;
	}
	
	public void Sum()
	{
		Number ++;
	}
		
}
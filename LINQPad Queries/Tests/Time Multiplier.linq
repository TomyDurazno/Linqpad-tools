<Query Kind="Program" />

void Main()
{
	var span = new TimeSpan(0, 0, 17);
	
	Enumerable.Range(0,3)
			  .Select(e => new TimeSpan(0, span.Minutes, span.Seconds))
			  .Aggregate((acum, ts) => acum + ts)
			  .Dump();
}

// Define other methods and classes here
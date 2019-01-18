<Query Kind="Program" />

void Main()
{
	var s = "hacercarnos ";
	
	//Pure Functional way, slower (48 s aprox)
	//Enumerable.Range(0,100000)
	//	.Select(o => s)
	//	.Aggregate((a,b) => a + b)
	//	.Dump();
	
	// OOP way, faster (0.146 s) aprox 328 times faster !! OMG
	var builder = new StringBuilder();
	
	Enumerable
			.Range(0,100000)
			.ToList()
			.ForEach(o => builder.Append(s));

		builder
			.ToString()
			.Dump();
}

// Define other methods and classes here
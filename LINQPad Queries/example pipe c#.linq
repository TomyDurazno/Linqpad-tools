<Query Kind="Program" />

void Main()
{	
	Enumerable.Range(1,10)
			  .Pipe(
				r => Enumerable.Select(r, n => n * 2),
				r => Enumerable.Where(r, n => n > 5),
				Enumerable.Sum,
				n => { Console.WriteLine(n); return n; }); 
				//Since WriteLine returns 'void'
}
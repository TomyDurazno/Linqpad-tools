<Query Kind="Program" />

void Main()
{
	MyUtils.ReadTxtFromDesktop("States.csv")
	.Select((s, i) =>
	{
		var splitted = s.SplitBy(",");
		return new State()
		{
			NAME = splitted.ElementAt(0),
			TESTED = splitted.ElementAt(1),
			POSITIVE = splitted.ElementAt(2),
			DEATHS = splitted.ElementAt(3)
		};
	}).Dump();
}

public class State
{
	public string NAME { get; set;}
	public string TESTED { get; set;}
	public string POSITIVE { get; set;}
	public string DEATHS { get; set;}
}



// Define other methods, classes and namespaces here

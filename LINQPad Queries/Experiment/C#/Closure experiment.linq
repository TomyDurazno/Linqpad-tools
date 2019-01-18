<Query Kind="Program" />

void Main()
{
	//Closure over 'start' variable
	var Add2 = MyUtils.MakeFunc(() =>
	{
		var start = 2;

		Func<TimeSpan> func = () =>
		{
			var span = TimeSpan.FromSeconds(start);
			start += 2;
			return span;
		};
		
		return func;
		
	}).Invoke();
	
	Add2().Dump();
		Add2().Dump();
			Add2().Dump();
}

// Define other methods and classes here

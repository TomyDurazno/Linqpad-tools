<Query Kind="Program" />

void Main()
{
	var lines = MyUtils.ReadTxt(@"C:\Users\tcordara\Documents\LINQPad Plugins\Framework 4.6\My Queries\Experiment\About My Extensions.linq");
		
	//lines.Dump();
	//var path = MyUtils.MyQueriesPath + "//About My Extensions.linq";
	lines.Dump();
	
	//lines2 = lines2.Select((l, i) => i == 9 ? "//" : l);

	//MyUtils.WriteTxt(lines2, path); //IOException
	//lines2.Dump();
}

// Define other methods and classes here
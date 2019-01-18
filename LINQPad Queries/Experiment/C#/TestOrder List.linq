<Query Kind="Program" />

void Main()
{
	var A = new List<string>(){"B","D","C","A","H"};
	
	var B = new List<string>(){"A","B","C","D"}
	
	 A.OrderBy(a => B.FindIndex(b => a == b)).Dump();
	 
}

// Define other methods and classes here

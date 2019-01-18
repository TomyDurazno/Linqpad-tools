<Query Kind="Program" />

void Main()
{
	var lista1 = new List<int>(){1,2,3};
	var lista2 = new List<int>(){4,5,6};
	var lista3 = new List<int>(){7,8,9};
	
	var arr = new List<int>[]{lista1,lista2,lista3};
	var auxList = new List<int>();	
	
	arr.ToList().Aggregate(auxList, (a,l) => { a.AddRange(l); return a;}).Dump();
	//arr.Dump();
}

// Define other methods and classes here

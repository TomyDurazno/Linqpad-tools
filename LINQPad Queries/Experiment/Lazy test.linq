<Query Kind="Program" />

void Main()
{
	var laz = new Lazy<string>(GetS);
	laz.Value.Dump();
	laz.Value.Dump();
	laz.Value.Dump();
	laz.Value.Dump();
}

// Define other methods and classes here
public static string GetS()
{
	return Guid.NewGuid().ToString().Split('-').First();
}
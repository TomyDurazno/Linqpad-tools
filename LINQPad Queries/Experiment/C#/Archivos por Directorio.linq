<Query Kind="Program" />

void Main()
{
	DirectoryInfo d = new DirectoryInfo(@"C:\Users\TCordara\Documents\LINQPad Queries");
	FileInfo[] Files = d.GetFiles("*.*", SearchOption.AllDirectories); //Getting All files
	Files
		.Select(f => new {Name = f.Name, Directory = f.Directory.Name})
		.GroupBy(f => f.Directory)
		.Select(g => new {Key = g.Key, Count = g.Count()})
		.Dump();
}

// Define other methods and classes here

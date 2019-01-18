<Query Kind="Program" />

void Main()
{	
	new DirectoryInfo(MyUtils.DesktopPath + "/requests")
					.GetFiles()
					.Project(files => new[]{ "new", "old" }.Select(f => files.Where(fs => fs.FullName.IndexOf(f) != -1)))
					.Select(nf => nf.Select(n => MyUtils.ReadTxt(n.FullName)
									   .Reverse()
									   .Take(4)
									   .Last()
									   .SplitBy(": ")
									   .ElementAt(1)
									   .Project(TimeSpan.Parse))
								.OrderBy(t => t))
					.Dump();
}
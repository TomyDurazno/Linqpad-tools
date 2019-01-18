<Query Kind="Program" />

void Main()
{	
	var date = new DateTime(2018,11, 1);
	
	new DirectoryInfo(MyUtils.DesktopPath + "//Tasks//DONE")
	   .EnumerateDirectories()
	   .Where(d => d.CreationTime >= date)
	   .OrderBy(d => d.CreationTime)
	   .Select(d => new { d.CreationTime,  Name = d.Name })
	   .GroupBy(d => d.CreationTime.Month + "/" +  d.CreationTime.Day).Dump();	   
}
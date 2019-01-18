<Query Kind="Program" />

void Main()
{
	var dirInfo = new DirectoryInfo(Tasker.Paths.DONE_Folder);

	var startTime = new DateTime(2018, 9, 1);

	var tasks = dirInfo.GetDirectories()
		   .OrderBy(d => d.CreationTime)
		   .Select(d => new { Txt = new DirectoryInfo(d.FullName).GetFiles("*.txt").Where(n => n.Name.IndexOf("Task") >= 0).First().Project(t => new { t.CreationTime, t.LastWriteTime, t.Name , Directory = d.Name})/*, d.CreationTime, d.LastWriteTime, d.Name, Subs = Directory.GetDirectories(d.FullName)*/})
		   .Where(d => d.Txt.CreationTime >= startTime)
		   .Select(d => d.Txt);

	var startTime2 = new DateTime(2018, 9, 1);
	
	var dates = Enumerable.Range(0,70).Select(e => startTime2.AddDays(e));

	var result = dates.Select(d => new { Date = d, Tasks = tasks.Where(t => IsInSpan(t.CreationTime, t.LastWriteTime, d)) });

	result.Dump();
}	

public bool IsInSpan(DateTime creation, DateTime lastWrite, DateTime mydate)
{
	return mydate.Date >= creation.Date && mydate.Date <= lastWrite.Date;	
}
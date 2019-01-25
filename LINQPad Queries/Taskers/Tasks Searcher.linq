<Query Kind="Program">
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

void Main()
{	
	var date = new DateTime(2018,11, 1);
	
	new DirectoryInfo(Tasker.Paths.DONE_Folder)
	   .EnumerateDirectories()
	   .Where(d => d.CreationTime >= date)
	   .OrderBy(d => d.CreationTime)
	   .Select(d => new { d.CreationTime,  Name = d.Name, Meta = GetAuthorizedFiles(d.FullName).Where(s => s.Contains("meta")).First().Pipe(ToMeta) })
	   .GroupBy(d => d.CreationTime.Month + "/" +  d.CreationTime.Day)
	   .Dump();
}

public Tasker.Meta ToMeta(string metasrc)
{
	return MyUtils.ReadTxt(metasrc).Pipe(string.Concat, JObject.Parse, j => j.ToObject<Tasker.Meta>());
}

List<string> GetDirectoriesRecursive(string parent)
{
	var directories = new List<string>();
	GetDirectoriesRecursive(directories, parent);
	return directories;
}

void GetDirectoriesRecursive(List<string> directories, string parent)
{
	directories.Add(parent);
	foreach (string child in GetAuthorizedDirectories(parent))
		GetDirectoriesRecursive(directories, child);
}

string[] GetAuthorizedDirectories(string dir)
{
	try { return Directory.GetDirectories(dir); }
	catch (UnauthorizedAccessException) { return new string[0]; }
}

string[] GetAuthorizedFiles(string dir)
{
	try { return Directory.GetFiles(dir); }
	catch (UnauthorizedAccessException) { return new string[0]; }
}
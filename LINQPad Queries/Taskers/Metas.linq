<Query Kind="Program">
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

void Main()
{	
	var metas = Tasker.Paths.DONE_Folder
					  .Project(df => new DirectoryInfo(df))
					  .EnumerateFiles("meta.txt", SearchOption.AllDirectories)
					  .Select(m => MyUtils.ReadTxt(m.FullName)
					  					  .ElementAt(0)
										  .Project(me => JObject.Parse(me)
										  						.ToObject<Tasker.Meta>()));

	metas.Dump();
}
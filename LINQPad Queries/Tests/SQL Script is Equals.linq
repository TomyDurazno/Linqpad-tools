<Query Kind="Program" />

void Main()
{	
	var directoryName = @"C:\Users\tcordara\Desktop\Tasks\DONE\21388 - Add Taxes configuration to SubCon Components\Scripts";
	
	var scriptName = "Subcon_component_custom_settings.sql";
	
	#region Implementation

	var directory = new DirectoryInfo(directoryName );
	
	var files = directory.GetFiles(scriptName, SearchOption.AllDirectories);
	
	var txt1 = MyUtils.ReadTxt(files.First().FullName);

	var results = files
	.Select(file => {

		var Result = txt1.Zip(MyUtils.ReadTxt(file.FullName), (t1, t2) => string.Compare(t1, t2));

		if (!Result.Project(IsEqual))
			return new { file.FullName, Result };
		else
			return new { FullName = string.Empty, Result };
	})
	.Where(file => file.FullName != string.Empty);
	
	if(!results.Any())
	{
		"No Differences!".Dump();
	}
	else
	{
		results.Dump();
	}

	#endregion
}

#region Functions

public bool IsEqual(IEnumerable<int> enums)
{
	var first = enums.First();
	
	var lasts = enums.Skip(1);

	//Is Equals if 'go' statement is different but body of sql is the same
	return new[] { -1, 0, 1 }.Any(n => n == first) && lasts.All(l => l == 0);
}

#endregion
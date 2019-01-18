<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\System.Web.Mvc.dll</Reference>
</Query>

void Main()
{	
	var people = new List<Person>()
	{
    	new Person{ Id = 1, Name = "Steve" },
    	new Person{ Id = 2, Name = "Bill" },
    	new Person{ Id = 3, Name = "John" },
    	new Person{ Id = 4, Name = "Larry" }
	};
	
	var List = new System.Web.Mvc.MultiSelectList(people, "Id", "Name", new[]{ 2, 3 });
	List.Dump();
}

public class Person
{
    public int Id{ get; set; }
    public string Name { get; set; }
}

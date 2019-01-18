<Query Kind="Program" />

void Main()
{
	var exp = MyUtils.ReadTxtFromDesktop("config.txt")
					 .Concatenate()
					 .Project(MyUtils.XMLToDynamic);
	
	Console.Write(exp.configuration.appSettings.add);
}

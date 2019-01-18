<Query Kind="Program" />

void Main()
{
	Action act = () => {
		var names = MyUtils.ReadTxtFromDesktop("john.txt");
	
	//Si no hago la llamada a 'ToList()', se dispara una IO exception ()
	//IOException: The process cannot access the file 'C:\Users\tcordara\Desktop\john.txt' because it is being used by another process.
	//Very interesting behaviour! thanks IEnumerable !
	
		MyUtils.WriteTxtToDesktop(names.ToList(), "john.txt");
	};
	
	Enumerable.Repeat(0,10).ToList().ForEach(s => act());
}

// Define other methods and classes here

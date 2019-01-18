<Query Kind="Program" />

void Main()
{
	Get<Obj>().Dump();
}

public class Obj 
{
	public string Name;
	
	public Obj()
	{
		Name = "John";	
	}
}

public T Get<T>() where T : new() 
{
	var type = typeof(T);
	type.Name.Dump();
	return new T();
}

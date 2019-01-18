<Query Kind="Program" />

void Main()
{
	var obj1 = new Obj1()
	{
		Name = "John",
		Age = "19",
		Last = "Richard"
	};
	
	var obj2 = new Obj2();
	
	MapObject(obj1, obj2).Dump();
}

public class Obj1
{
	public string Name { get; set; }
	
	public string Age { get; set; }
	
	public string Last { get; set; }
}

public class Obj2
{
	public string Name { get; set; }

	public string Age { get; set; }

	public string Last { get; set; }
}

public T MapObject<T,K>(K originalObj, T reciver)
{
	var orProps = originalObj.GetType().GetProperties();
	
	var recivProps = reciver.GetType().GetProperties();
	
	foreach (var prop in orProps)
	{
		var p = recivProps.FirstOrDefault(f => f.Name == prop.Name);
		
		if(p != null)
		{
			p.SetValue(reciver, prop.GetValue(originalObj));
		}
	}
	
	return reciver;
}
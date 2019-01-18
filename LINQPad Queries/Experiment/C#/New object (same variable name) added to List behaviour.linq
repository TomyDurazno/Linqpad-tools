<Query Kind="Program" />

void Main()
{
	var list = new List<Obj>();
	Obj o;
	o = new Obj("John");
	list.Add(o);
	o = new Obj("Peter"); 
	list.Add(o);
	o = new Obj("Richard");
	list.Add(o);
	
	list.Dump();
	
	//Conclusion: 'new' keyword does some kind of magic! (CLR magic)
}

public class Obj
{
	public string Nombre {get;set;}
	
	public Obj(string nom)
	{
		Nombre = nom;
	}
}
<Query Kind="Program" />

void Main()
{
	new Hey(11).Say().Dump();
}

public class Hey
{
	dynamic nom;
	public Hey(dynamic aux)
	{
		nom = aux;
	}
	
	public string Say(){
		return nom.ToString();
	}
}

// Define other methods and classes here
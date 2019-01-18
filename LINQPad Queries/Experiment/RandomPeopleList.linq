<Query Kind="Program" />

void Main()
{
    var r = new Random();
	var list = new List<Persona>();
	
    for(int i=0; i<1000;i++)
	{
	
	var un = r.Next(1900,2000);
	var dos = r.Next(1900,2000);
	var nom = r.Next(3,7);
	
	var nac = GetLower(un,dos);
	var dead = GetHigher(un,dos);
	
	if(nac == dead){
		if(nac == 1900){
		dead = dead+1;
		}
		if(dead== 2000){
		nac = nac-1;
		}
	}
	
	var p = new Persona(GenerateName(nom,r),nac,dead);
	
	list.Add(p);
	}
	
	list.DumpJson();
}

public static string GenerateName(int len, Random r)
        {
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

public class Persona {
	public string Nombre {get; set;}
	public int Nacimiento {get; set;}
	public int Muerte {get; set;}
	
	public Persona(string nom, int nac, int muer)
	{
		this.Nombre = nom;
		this.Nacimiento = nac;
		this.Muerte = muer;
	}
}

public int GetLower(int un, int dos){
	if(un>dos){
		return dos;
	}else{
	return un;
	}
}

public int GetHigher(int un, int dos){
	if(un>dos){
		return un;
	}else{
	return dos;
	}
}
<Query Kind="Program" />

void Main()
{
	var t = new DateTime(2000,1,1);
	var inicio = t.ToString().Split();
	inicio[0].Dump("Fecha Inicial");
	var ListaResultados = new List<DateTime>();
	var cont=1;
	while(t.Year<3000)
	{
		if(esPalindromo(DateToString(t)))
		{
		ListaResultados.Add(t);
		}
		t = t.AddDays(1);
		cont++;
	}
	var final = t.ToString().Split();
	
	final[0].Dump("Fecha Final");
	
	cont.Dump("Días Evaluados");
	
	ListaResultados.Count().Dump("Días Palíndromos");
	
	double r = ((double)ListaResultados.Count()/(double)cont)*100;
	 var rer = r.ToString()+"%";
	 rer.Dump("Porcentaje de días palíndromos");
	 
	 var s = "";
	 s.Dump("Resultados");
	 
	 foreach(var d in ListaResultados)
	 {
	 var x = d.ToString().Split();
	 x[0].Dump("");
	 }
	 

}

string DateToString(DateTime tiempo)
{
	var auxtiempo = tiempo.ToString();
	var a = auxtiempo.Split();
	var r= a[0].Replace(@"/", ""); 
	return r;
}

bool esPalindromo(string auxS)
{
	if(auxS.Equals(Reverse(auxS)))
	{
	return true;
	}
	return false;
}

public static string Reverse( string s )
{
    char[] charArray = s.ToCharArray();
    Array.Reverse( charArray );
    return new string( charArray );
}

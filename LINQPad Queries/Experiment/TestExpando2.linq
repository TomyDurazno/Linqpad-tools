<Query Kind="Program">
  <Reference Relative="..\..\Desktop\Querys\LINQPad\Newtonsoft.Json.dll">C:\Users\TCordara\Desktop\Querys\LINQPad\Newtonsoft.Json.dll</Reference>
</Query>

void Main()
{
	var dic = new Dictionary<string,DateTime?>();
	dic.Add("Inspeccionar", DateTime.Now.AddDays(10));
	dic.Add("Archivar", DateTime.Now.AddDays(20));
	dic.Add("Calificar", DateTime.Now.AddDays(30));
	
	var i = new Indicador("A", DateTime.Now,dic);
	
	var response = new System.Dynamic.ExpandoObject();
	
	foreach (PropertyInfo pi in i.GetType().GetProperties())
    {
		if(!pi.GetValue(i,null).ToString().Contains("Dictionary"))
		{
			(response as IDictionary<string, object>)[pi.Name] =  pi.GetValue(i,null).ToString();
		}

    }
	
	// Convierte un diccionario en un expando object
	foreach(var kvp in dic)
	{
    	(response as IDictionary<string, object>)[kvp.Key] = kvp.Value;
	}
	
	(response as IDictionary<string, object>).Keys.Dump();
	(response as IDictionary<string, object>).Values.Dump();
}

public class Indicador
    {
        public string Alias { get; set; }
        public DateTime? FechaInspeccion { get; set; }
        public Dictionary<string, DateTime?> Actividades { get; set; }

		public Indicador(string alias, DateTime? fecha, Dictionary<string,DateTime?> dic)
		{
			this.Alias = alias;
			this.FechaInspeccion = fecha;
			this.Actividades = dic;
		}
    }
	
// Define other methods and classes here

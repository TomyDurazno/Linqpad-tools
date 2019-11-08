<Query Kind="Program" />

void Main()
{
	
	var desde = new DateTime(2017,03,22);
	var ind = new Indicadores(){
		FechaInspeccionDesde = desde
	};
	
	object tes = ind;
	tes.GetType().GetMethod("Hablar").Invoke(tes,null).Dump();
}

public class Indicadores
    {
        public int[] Areas { get; set; }
        public string DireccionGeneral { get; set; }
        public DateTime? FechaInspeccionDesde { get; set; }
        public DateTime? FechaInspeccionHasta { get; set; }
        public string[] Inspectores { get; set; }
		
		public string Hablar(){
			return FechaInspeccionDesde.ToString();
		}
    }
// Define other methods and classes here
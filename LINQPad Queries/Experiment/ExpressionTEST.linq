<Query Kind="Program">
  <Connection>
    <ID>421df7e0-28e8-4e45-b629-6348bb1ae26d</ID>
    <Persist>true</Persist>
    <Server>(localdb)\v11.0</Server>
    <Database>VMTII</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	int[] ids = new int[]{1,2,3,4};
	
	var l = ToListaTitulares("1,2,3,5");
	l.Dump();
	
}

    public List<Titular> ToListaTitulares (string TitularesInput)
        {     
            if (TitularesInput != string.Empty)
            {
                var idTitulares = TitularesInput.Split(',').ToList().Select(i => Convert.ToInt32(i));              
                return Titulars.Where(t => idTitulares.Contains(t.Id)).ToList();               
            }

            return new List<Titular>();
        }
// Define other methods and classes here

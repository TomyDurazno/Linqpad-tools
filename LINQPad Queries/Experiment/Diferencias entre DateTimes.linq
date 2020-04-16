<Query Kind="Program" />

void Main()
{
	   var x = new DateTime(2016,08,01);
       var y = new DateTime(2017,04,20);
	   
	   DiasEntre(x,y).Count().Dump();
	   
	   (x - y).Pipe(n => - n).TotalDays.Dump();
}

        private IEnumerable<DateTime> DiasEntre(DateTime d0, DateTime d1)
        {
          var list = new List<DateTime>();
		   var auxTime = d1.Date;
		   while((auxTime - d0).TotalDays>0)
		   {
		   		list.Add(auxTime);
				auxTime = auxTime.AddDays(-1);
		   }

		   return list.OrderBy(x=>x);
        }
		
		        private IEnumerable<DateTime> MesesEntre(DateTime d0, DateTime d1)
        {
            return Enumerable.Range(0, (d1.Year - d0.Year) * 12 + (d1.Month - d0.Month + 1))
                             .Select(m => new DateTime(d0.Year, d0.Month, 1).AddMonths(m));
        }
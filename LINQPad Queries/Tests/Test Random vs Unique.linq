<Query Kind="Program" />

void Main()
{

	var keys = Enumerable.Range(0, 10000)
			  			 .Select(n => new { Unique = GenerateUnique(), Random = GenerateRandom()})
						 .ToList().Dump();	


}


public string GenerateUnique()
{
	int num = 0;									  
	do
		try 
		{ 
			num = Convert.ToInt32(Guid.NewGuid()
									  .ToString()
									  .ToCharArray()
									  .Where(c => char.IsNumber(c))
									  .Take(8)
									  .Aggregate(new StringBuilder(), (acum, item) => acum.Append(item))									  
									  .ToString()); 
		}
		catch(Exception)
		{
		}			
	while(!(num > 11111111 && num < 99999999));
	
	return num.ToString();
}

public string GenerateRandom()
{
		    StringBuilder sb = new StringBuilder();
            sb.Append("CT");

            const int minimum = 11111111;
            const int maximum = 99999999;

            Random random = new Random();
            sb.Append(random.Next(minimum, maximum));
			
			return sb.ToString();
}
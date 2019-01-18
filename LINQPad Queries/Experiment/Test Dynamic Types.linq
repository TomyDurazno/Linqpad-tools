<Query Kind="Program" />

void Main()
{	  
 	 var l = new List<dynamic>();
 	 
	 l.Add("Hey");
	 l.Add(1);	 
	 
  	if(l is IEnumerable){
		true.Dump();
	}

}

// Define other methods and classes here

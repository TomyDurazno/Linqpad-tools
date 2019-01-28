<Query Kind="Program">
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

void Main()
{
	//JSON Pretty printer	
	 @"C:\Users\tcordara\Downloads\Hepha state_Tue Jan 15 2019_.json"
		   .Pipe(
		    MyUtils.ReadTxt,			 			   		 
		   	string.Concat, 
			JObject.Parse,
			j => j.DumpJson());
}
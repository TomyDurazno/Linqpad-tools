<Query Kind="Program">
  <Namespace>System.Web</Namespace>
</Query>

#load "MultilineIO"

void Main()
{
	var input = new MultilineIO();

	input.Create(i => {
	
	HttpUtility.UrlDecode(i).Dump();
	
	});
}

// Define other methods, classes and namespaces here
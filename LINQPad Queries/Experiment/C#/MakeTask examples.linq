<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var newTask = MyUtils.MakeTask(GetMessage(), (s) => new { Message = s, Version = true }); 
	
	var result = await newTask;
	
	result.Dump();
}

public async Task<string> GetMessage()
{
	await Task.Delay(2000);
	return "Message";
}

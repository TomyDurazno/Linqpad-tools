<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main()
{
	string GetName(int n)
	{
		var builder = new StringBuilder();
		
		void Append() => builder.Append(MyUtils.RandomName(32));
		
		Append();
		Append();
		Append();
		
		return builder.ToString();
	}
	
	var lines = Enumerable.Range(0, 100000)
						  .Select(GetName);
	
	void Write()
	{
		MyUtils.WriteTxtToDesktop(lines, "test2gb.txt");
	}	
	
	MyUtils.SetIntervalAsync(3000, new TimeSpan(17, 56, 00), Write);
}

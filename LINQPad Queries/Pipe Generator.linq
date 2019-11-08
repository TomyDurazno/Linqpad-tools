<Query Kind="Program" />

void Main()
{
	var capitals = Enumerable.Range(65, 26)
							 .Select(e => (char)e);

	#region MakePipeByNumberOfFuncs
	
	string MakePipeByNumberOfFuncs(int r)
	{
		var types = capitals.Take(r).ToList();

		var commaSplited = types.SelectMany(t => new[] { ",", t.ToString() })
								.Skip(1)
								.Pipe(string.Concat);

		var firstType = capitals.First();
		
		var lastType = capitals.ElementAt(r - 1);

		var funcs = Enumerable.Range(1, r - 1).Select(e => $"func{e}");

		var funcTypes = types.Select((t, i) => i < types.Count() - 1 ? new[] { t, types.ElementAt(i + 1) } : null)
			 				 .Where(a => a != null)
							 .Select(a => $"Func<{a[0]},{a[1]}>");

		var funcsCommaSplited = funcTypes.SelectMany((t, i) => new[] { ", ", $"{ t.ToString() } { funcs.ElementAt(i) }" })
											 .Skip(1)
											 .Pipe(string.Concat);

		var funcsInside = funcs.Reverse()
							   .Select(f => $"{f}(")
							   .Pipe(string.Concat); 

		var closingParenthesis = funcs.Select(f => ")")
									  .Pipe(string.Concat);

		string summary(int n) =>
		@"/// <summary>
/// Pipes " + (n - 1) + @" functions
/// </summary>";

		var format = $"public static {lastType} Pipe<{commaSplited}>(this {firstType} obj, {funcsCommaSplited}) => {funcsInside}obj{closingParenthesis};";

		return new [] { string.Empty, summary(r), format }.Aggregate(new StringBuilder(), (acum, s) => acum.AppendLine(s)).ToString();
	}
	
	#endregion
	
	var limit = capitals.Count() - 1; //types A to Z
	
	Enumerable.Range(2, limit)
			  .Select(MakePipeByNumberOfFuncs)
			  .Dump();
}
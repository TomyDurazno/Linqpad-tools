<Query Kind="Program" />

void Main()
{
	var rnd = new Random();
	
	Enumerable.Range(0,1000).Select(e => GetPass(rnd)).Where(s => !string.IsNullOrEmpty(s)).Project(a => string.Join(",",a)).Dump();
}

public static string GetPass(Random rnd)
{	
	var isUse = rnd.Next() % 4 == 0;
	System.Func<char, bool> wherer = c => isUse ? char.IsLetterOrDigit(c) : char.IsDigit(c);
	return Enumerable.Range(0, 20).Select(e => GetLetter(rnd)).Where(wherer).Take(4).Aggregate (new StringBuilder(), (acum, y) => acum.Append(y)).ToString();	
}

public static char GetLetter(Random rand)
{
	string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
	int num = rand.Next(0, chars.Length - 1);
	return chars[num];
}

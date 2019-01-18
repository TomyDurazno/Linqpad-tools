<Query Kind="Program" />

void Main()
{
	var x = "testS";
	
	x.ToMaybe().Dump();
	//var r = from x in 5.ToMaybe()
       		//from y in Maybe<int>.Nothing
        	//select x + y;

	//Console.WriteLine(r.HasValue ? r.Value.ToString() : "Nothing");
	
	//var s = "Letter";
	//s.ToMaybe().Dump();
}

public class Maybe<T>
{
    public readonly static Maybe<T> Nothing = new Maybe<T>();
    public T Value { get; private set; }
    public bool HasValue { get; private set; }
   
	Maybe()
    {
        HasValue = false;
    }
  
	public Maybe(T value)
    {
        Value = value;
        HasValue = true;
    }
	
	
}

public static class Ext{
	
	public static Maybe<T> ToMaybe<T>(this T value)
	{
    	return new Maybe<T>(value);
	}
	
	public static Maybe<U> SelectMany<T, U>(this Maybe<T> m, Func<T, Maybe<U>> k)
	{
    	if (!m.HasValue)
        	return Maybe<U>.Nothing;
    	return k(m.Value);
	}
}
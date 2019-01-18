<Query Kind="Program" />

void Main()
{
	string s = null;
	s.ToWrapper().Ok().Dump();
	
	
}

// Define other methods and classes here


    /// <summary> Clase abstracta usada para expandir tipos
    /// </summary>
    /// <typeparam name="T"></typeparam>
public class IWrapper<T>
{
    private T obj;
	
	public IWrapper(T elem){
		obj = elem;
	}
        /// <summary> Retorna el objeto encapsulado
        /// </summary>
        /// <returns></returns>
    public T Get() {
        return obj;
    }
	
	public bool Ok(){
		return obj != null;
	}
}

public static class IWrapperExt{

	public static IWrapper<T> ToWrapper<T>(this T obj)
	{
		return new IWrapper<T>(obj);
	}
}



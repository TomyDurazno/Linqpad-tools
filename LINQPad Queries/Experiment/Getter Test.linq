<Query Kind="Program" />

void Main()
{
	var g = new Delayer<string>(Auth);	
	g.Dump();
	g.Dump();
	g.Dump();
	g.Dump();
	g.Dump();
}

public static string Auth(){
	return new Random().Next(100).ToString();
}

    /// <summary> Clase utilizada para encapsular la ejecución de una función 
    /// con el objetivo de ejecutarla una sola vez y consumir el valor que devuelve
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Delayer<T> where T : class
    {

        private T _Item;
        private Func<T> _Func;

        /// <summary> Clase utilizada para encapsular la ejecución de una función 
        /// con el objetivo de ejecutarla una sola vez y consumir el valor que devuelve
        /// </summary>
        /// <param name="auxFunc">Función a encapsular </param>
        public Delayer(Func<T> auxFunc)
        {
            _Func = auxFunc;
        }

        /// <summary> Devuelve el valor encapsulado si existe. 
        /// Si no fue seteado, lo setea ejecutando la función encapsulada
        /// </summary>
        public T Get
        {
            get
            {
                _Item = _Item ?? _Func();

                return _Item;
            }
        }
    }

// Define other methods and classes here

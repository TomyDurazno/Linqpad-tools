<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Entity.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Reflection.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Reflection.Emit.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <NuGetReference>DeepEqual</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <NuGetReference>NPOI</NuGetReference>
  <NuGetReference>RestSharp</NuGetReference>
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>NPOI.HSSF.UserModel</Namespace>
  <Namespace>NPOI.XSSF.UserModel</Namespace>
  <Namespace>RestSharp</Namespace>
  <Namespace>System.Dynamic</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
</Query>

void Main() { }

#region MyExtensions

public static class MyExtensions
{
	#region Powerful one-liners	
	
	/// <summary>
	/// Calls an action over a variable and then returns that variable
	/// </summary>
	public static T Mutate<T>(this T obj, Action<T> act) { act.Invoke(obj); return obj; }

	#region Pipe

	/// <summary>
	/// Pipes 1 functions
	/// </summary>
	public static B Pipe<A,B>(this A obj, Func<A,B> func1) => func1(obj); 
	
	/// <summary>
	/// Pipes 2 functions
	/// </summary>
	public static C Pipe<A,B,C>(this A obj, Func<A,B> func1, Func<B,C> func2) => func2(func1(obj)); 
	
	/// <summary>
	/// Pipes 3 functions
	/// </summary>
	public static D Pipe<A,B,C,D>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3) => func3(func2(func1(obj))); 
	
	/// <summary>
	/// Pipes 4 functions
	/// </summary>
	public static E Pipe<A,B,C,D,E>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4) => func4(func3(func2(func1(obj)))); 
	
	/// <summary>
	/// Pipes 5 functions
	/// </summary>
	public static F Pipe<A,B,C,D,E,F>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4, Func<E,F> func5) => func5(func4(func3(func2(func1(obj))))); 
	
	/// <summary>
	/// Pipes 6 functions
	/// </summary>
	public static G Pipe<A,B,C,D,E,F,G>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4, Func<E,F> func5, Func<F,G> func6) => func6(func5(func4(func3(func2(func1(obj)))))); 
	
	/// <summary>
	/// Pipes 7 functions
	/// </summary>
	public static H Pipe<A,B,C,D,E,F,G,H>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4, Func<E,F> func5, Func<F,G> func6, Func<G,H> func7) => func7(func6(func5(func4(func3(func2(func1(obj))))))); 
	
	/// <summary>
	/// Pipes 8 functions
	/// </summary>
	public static I Pipe<A,B,C,D,E,F,G,H,I>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4, Func<E,F> func5, Func<F,G> func6, Func<G,H> func7, Func<H,I> func8) => func8(func7(func6(func5(func4(func3(func2(func1(obj)))))))); 
	
	/// <summary>
	/// Pipes 9 functions
	/// </summary>
	public static J Pipe<A,B,C,D,E,F,G,H,I,J>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4, Func<E,F> func5, Func<F,G> func6, Func<G,H> func7, Func<H,I> func8, Func<I,J> func9) => func9(func8(func7(func6(func5(func4(func3(func2(func1(obj))))))))); 
	
	/// <summary>
	/// Pipes 10 functions
	/// </summary>
	public static K Pipe<A,B,C,D,E,F,G,H,I,J,K>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4, Func<E,F> func5, Func<F,G> func6, Func<G,H> func7, Func<H,I> func8, Func<I,J> func9, Func<J,K> func10) => func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj)))))))))); 
	
	/// <summary>
	/// Pipes 11 functions
	/// </summary>
	public static L Pipe<A,B,C,D,E,F,G,H,I,J,K,L>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4, Func<E,F> func5, Func<F,G> func6, Func<G,H> func7, Func<H,I> func8, Func<I,J> func9, Func<J,K> func10, Func<K,L> func11) => func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj))))))))))); 
	
	/// <summary>
	/// Pipes 12 functions
	/// </summary>
	public static M Pipe<A,B,C,D,E,F,G,H,I,J,K,L,M>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4, Func<E,F> func5, Func<F,G> func6, Func<G,H> func7, Func<H,I> func8, Func<I,J> func9, Func<J,K> func10, Func<K,L> func11, Func<L,M> func12) => func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj)))))))))))); 
	
	/// <summary>
	/// Pipes 13 functions
	/// </summary>
	public static N Pipe<A,B,C,D,E,F,G,H,I,J,K,L,M,N>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4, Func<E,F> func5, Func<F,G> func6, Func<G,H> func7, Func<H,I> func8, Func<I,J> func9, Func<J,K> func10, Func<K,L> func11, Func<L,M> func12, Func<M,N> func13) => func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj))))))))))))); 
	
	/// <summary>
	/// Pipes 14 functions
	/// </summary>
	public static O Pipe<A,B,C,D,E,F,G,H,I,J,K,L,M,N,O>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4, Func<E,F> func5, Func<F,G> func6, Func<G,H> func7, Func<H,I> func8, Func<I,J> func9, Func<J,K> func10, Func<K,L> func11, Func<L,M> func12, Func<M,N> func13, Func<N,O> func14) => func14(func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj)))))))))))))); 
	
	/// <summary>
	/// Pipes 15 functions
	/// </summary>
	public static P Pipe<A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4, Func<E,F> func5, Func<F,G> func6, Func<G,H> func7, Func<H,I> func8, Func<I,J> func9, Func<J,K> func10, Func<K,L> func11, Func<L,M> func12, Func<M,N> func13, Func<N,O> func14, Func<O,P> func15) => func15(func14(func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj))))))))))))))); 
	
	/// <summary>
	/// Pipes 16 functions
	/// </summary>
	public static Q Pipe<A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q>(this A obj, Func<A,B> func1, Func<B,C> func2, Func<C,D> func3, Func<D,E> func4, Func<E,F> func5, Func<F,G> func6, Func<G,H> func7, Func<H,I> func8, Func<I,J> func9, Func<J,K> func10, Func<K,L> func11, Func<L,M> func12, Func<M,N> func13, Func<N,O> func14, Func<O,P> func15, Func<P,Q> func16) => func16(func15(func14(func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj))))))))))))))));

	/// <summary>
	/// Pipes 17 functions
	/// </summary>
	public static R Pipe<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7, Func<H, I> func8, Func<I, J> func9, Func<J, K> func10, Func<K, L> func11, Func<L, M> func12, Func<M, N> func13, Func<N, O> func14, Func<O, P> func15, Func<P, Q> func16, Func<Q, R> func17) => func17(func16(func15(func14(func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj)))))))))))))))));

	/// <summary>
	/// Pipes 18 functions
	/// </summary>
	public static S Pipe<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7, Func<H, I> func8, Func<I, J> func9, Func<J, K> func10, Func<K, L> func11, Func<L, M> func12, Func<M, N> func13, Func<N, O> func14, Func<O, P> func15, Func<P, Q> func16, Func<Q, R> func17, Func<R, S> func18) => func18(func17(func16(func15(func14(func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj))))))))))))))))));

	/// <summary>
	/// Pipes 19 functions
	/// </summary>
	public static T Pipe<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7, Func<H, I> func8, Func<I, J> func9, Func<J, K> func10, Func<K, L> func11, Func<L, M> func12, Func<M, N> func13, Func<N, O> func14, Func<O, P> func15, Func<P, Q> func16, Func<Q, R> func17, Func<R, S> func18, Func<S, T> func19) => func19(func18(func17(func16(func15(func14(func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj)))))))))))))))))));

	/// <summary>
	/// Pipes 20 functions
	/// </summary>
	public static U Pipe<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7, Func<H, I> func8, Func<I, J> func9, Func<J, K> func10, Func<K, L> func11, Func<L, M> func12, Func<M, N> func13, Func<N, O> func14, Func<O, P> func15, Func<P, Q> func16, Func<Q, R> func17, Func<R, S> func18, Func<S, T> func19, Func<T, U> func20) => func20(func19(func18(func17(func16(func15(func14(func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj))))))))))))))))))));

	/// <summary>
	/// Pipes 21 functions
	/// </summary>
	public static V Pipe<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7, Func<H, I> func8, Func<I, J> func9, Func<J, K> func10, Func<K, L> func11, Func<L, M> func12, Func<M, N> func13, Func<N, O> func14, Func<O, P> func15, Func<P, Q> func16, Func<Q, R> func17, Func<R, S> func18, Func<S, T> func19, Func<T, U> func20, Func<U, V> func21) => func21(func20(func19(func18(func17(func16(func15(func14(func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj)))))))))))))))))))));

	/// <summary>
	/// Pipes 22 functions
	/// </summary>
	public static W Pipe<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7, Func<H, I> func8, Func<I, J> func9, Func<J, K> func10, Func<K, L> func11, Func<L, M> func12, Func<M, N> func13, Func<N, O> func14, Func<O, P> func15, Func<P, Q> func16, Func<Q, R> func17, Func<R, S> func18, Func<S, T> func19, Func<T, U> func20, Func<U, V> func21, Func<V, W> func22) => func22(func21(func20(func19(func18(func17(func16(func15(func14(func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj))))))))))))))))))))));

	/// <summary>
	/// Pipes 23 functions
	/// </summary>
	public static X Pipe<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7, Func<H, I> func8, Func<I, J> func9, Func<J, K> func10, Func<K, L> func11, Func<L, M> func12, Func<M, N> func13, Func<N, O> func14, Func<O, P> func15, Func<P, Q> func16, Func<Q, R> func17, Func<R, S> func18, Func<S, T> func19, Func<T, U> func20, Func<U, V> func21, Func<V, W> func22, Func<W, X> func23) => func23(func22(func21(func20(func19(func18(func17(func16(func15(func14(func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj)))))))))))))))))))))));

	/// <summary>
	/// Pipes 24 functions
	/// </summary>
	public static Y Pipe<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7, Func<H, I> func8, Func<I, J> func9, Func<J, K> func10, Func<K, L> func11, Func<L, M> func12, Func<M, N> func13, Func<N, O> func14, Func<O, P> func15, Func<P, Q> func16, Func<Q, R> func17, Func<R, S> func18, Func<S, T> func19, Func<T, U> func20, Func<U, V> func21, Func<V, W> func22, Func<W, X> func23, Func<X, Y> func24) => func24(func23(func22(func21(func20(func19(func18(func17(func16(func15(func14(func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj))))))))))))))))))))))));

	/// <summary>
	/// Pipes 25 functions
	/// </summary>
	public static Z Pipe<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7, Func<H, I> func8, Func<I, J> func9, Func<J, K> func10, Func<K, L> func11, Func<L, M> func12, Func<M, N> func13, Func<N, O> func14, Func<O, P> func15, Func<P, Q> func16, Func<Q, R> func17, Func<R, S> func18, Func<S, T> func19, Func<T, U> func20, Func<U, V> func21, Func<V, W> func22, Func<W, X> func23, Func<X, Y> func24, Func<Y, Z> func25) => func25(func24(func23(func22(func21(func20(func19(func18(func17(func16(func15(func14(func13(func12(func11(func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj)))))))))))))))))))))))));

	#endregion

	public static J Pipe2<T, K, J>(this ValueTuple<T, K> tuple, Func<T, K, J> func) => func(tuple.Item1, tuple.Item2);
	
	public static S Pipe3<T, K, J, S>(this ValueTuple<T, K, J> tuple, Func<T, K, J, S> func) => func(tuple.Item1, tuple.Item2, tuple.Item3);

	#endregion

	#region DistinctBy

	//Gracias Jon Skeet!	
	public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		var seenKeys = new HashSet<TKey>();
		foreach (TSource element in source)
		{
			if (seenKeys.Add(keySelector(element)))
				yield return element;
		}
	}

	#endregion

	#region DumpJson

	public static object DumpJson(this object value, string description = null)
	{
		return GetJsonDumpTarget(value).Dump(description);
	}

	public static object DumpJson(this object value, string description, int depth)
	{
		return GetJsonDumpTarget(value).Dump(description, depth);
	}

	public static object DumpJson(this object value, string description, bool toDataGrid)
	{
		return GetJsonDumpTarget(value).Dump(description, toDataGrid);
	}

	private static object GetJsonDumpTarget(object value)
	{
		object dumpTarget = value;
		//if this is a string that contains a JSON object, do a round-trip serialization to format it:
		var stringValue = value as string;
		if (stringValue != null)
		{
			if (stringValue.Trim().StartsWith("{"))
			{
				var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(stringValue);
				dumpTarget = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
			}
			else
			{
				dumpTarget = stringValue;
			}
		}
		else
		{
			dumpTarget = Newtonsoft.Json.JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented);
		}
		return dumpTarget;
	}

	#endregion

	#region String Extensions

	public static string Concatenate(this IEnumerable<string> auxs)
		=> Concatenate(auxs, (builder, s) => builder.Append(s));

	public static string ConcatenateLines(this IEnumerable<string> auxs)
		=> Concatenate(auxs, (builder, s) => builder.AppendLine(s));

	public static string Concatenate(this IEnumerable<string> auxs, Func<StringBuilder, string, StringBuilder> mutate)
		=> auxs.Aggregate(new StringBuilder(), mutate).ToString();

	public static string Replace(this string s, IEnumerable<string> values, string newVal)
	{
		string auxS = s;
		
		foreach (var value in values)
		{
			auxS = auxS.Replace(value, newVal);
		}
		
		return auxS;
	}

	#endregion

	#region Tasks Extensions

	/// <summary>
	/// Continues a Task
	/// </summary>
	/// <param name="task"></param>
	/// <param name="func"></param>	
	public static Task<K> Then<T, K>(this Task<T> task, Func<T, K> func)
		=> task.ContinueWith(t => func(t.Result));

	#endregion

	#region Dictionary Helpers

	public static Dictionary<T, K> DictionaryOf<T, K>(this ValueTuple<T, K> tuplePairs)
	=> new[] { tuplePairs }.DictionaryOf();

	public static Dictionary<T, K> DictionaryOf<T, K>(this ValueTuple<T, K>[] tuplePairs)
	=> tuplePairs.ToDictionary(k => k.Item1, v => v.Item2);

	#endregion

	#region Apply

	public static S Apply<T, K, S>(this ValueTuple<T, K> tuple, Func<T, K, S> func)
	=> func(tuple.Item1, tuple.Item2);

	public static R Apply<T, K, S, R>(this ValueTuple<T, K, S> tuple, Func<T, K, S, R> func)
	=> func(tuple.Item1, tuple.Item2, tuple.Item3);

	public static G Apply<T, K, S, R, G>(this ValueTuple<T, K, S, R> tuple, Func<T, K, S, R, G> func)
	=> func(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);

	public static H Apply<T, K, S, R, G, H>(this ValueTuple<T, K, S, R, G> tuple, Func<T, K, S, R, G, H> func)
	=> func(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);

	public static J Apply<T, K, S, R, G, H, J>(this ValueTuple<T, K, S, R, G, H> tuple, Func<T, K, S, R, G, H, J> func)
	=> func(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6);

	#endregion

	#region Closure

	public static Func<S> Closure<T, K, S>(this ValueTuple<T, K> tuple, Func<T, K, S> func)
	=> () => func(tuple.Item1, tuple.Item2);

	public static Func<R> Closure<T, K, S, R>(this ValueTuple<T, K, S> tuple, Func<T, K, S, R> func)
	=> () => func(tuple.Item1, tuple.Item2, tuple.Item3);

	public static Func<G> Closure<T, K, S, R, G>(this ValueTuple<T, K, S, R> tuple, Func<T, K, S, R, G> func)
	=> () => func(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);

	public static Func<H> Closure<T, K, S, R, G, H>(this ValueTuple<T, K, S, R, G> tuple, Func<T, K, S, R, G, H> func)
	=> () => func(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);

	public static Func<J> Closure<T, K, S, R, G, H, J>(this ValueTuple<T, K, S, R, G, H> tuple, Func<T, K, S, R, G, H, J> func)
	=> () => func(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6);

	#endregion

	#region Fields Extensions

	public static Dictionary<string, string> FieldsToDictionary(this object obj)
	=> obj.GetType()
		  .GetFields()
		  .Select(f => new { f.Name, Value = f.GetValue(obj)?.ToString() })
		  .ToDictionary(a => a.Name, a => a.Value);

	public static IOrderedEnumerable<IGrouping<char, string>> FieldsByName<T>(this T obj)
	{
		return obj.GetType()
				  .GetFields()
				  .Select(f => f.Name)
				  .GroupBy(f => f[0])
				  .OrderBy(f => f.Key);
	}

	#endregion

	/// <summary>
	/// Splits a sequence of elements by a condition
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="elements"></param>
	/// <param name="predicate"></param>
	/// <returns></returns>
	public static (List<T> Included, List<T> Excluded) Split<T>(this IEnumerable<T> elements, Func<T, bool> predicate)
	{
		var included = new List<T>();
		var excluded = new List<T>();

		foreach (var item in elements)
		{
			if (predicate(item))
				included.Add(item);
			else
				excluded.Add(item);
		}

		return (included, excluded);
	}

	#region ChunkBy

	public static List<List<T>> ChunkBy<T>(this IEnumerable<T> elements, Func<T, int, bool> predicate, bool includeSeparator = false)
	{
		var acum = new List<T>();
		var all = new List<List<T>>();
		var count = 0;

		foreach (var element in elements)
		{
			if (predicate(element, count))
			{
				if (includeSeparator)
					acum.Add(element);

				all.Add(acum.ToList());
				acum = new List<T>();
			}
			else
			{
				acum.Add(element);
			}

			count++;
		}

		all.Add(acum);

		return all;
	}

	/// <summary>
	/// Chunks a sequence of elements in subgroups of elements by a common predicate
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="elements"></param>
	/// <param name="predicate"></param>
	/// <returns></returns>
	public static List<List<T>> ChunkBy<T>(this IEnumerable<T> elements, Func<T, bool> predicate)
	{
		var acum = new List<T>();
		var all = new List<List<T>>();
		var firstTime = true;

		foreach (var element in elements)
		{
			if (predicate(element))
			{
				if (firstTime)
				{
					acum.Add(element);
					firstTime = false;
				}
				else
				{
					all.Add(acum.ToList());
					acum = new List<T>();
					acum.Add(element);
				}
			}
			else
			{
				acum.Add(element);
			}
		}

		all.Add(acum);

		return all;
	}

	#endregion

	#region XmlExtensions
	
    public static XmlDocument ToXmlDocument(this XDocument xDocument)
	{
            var xmlDocument = new XmlDocument();

            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }

            return xmlDocument;
	}

        public static IEnumerable<XmlNode> GetNodes(this XmlNodeList nodelist)
        {
	            foreach (var element in nodelist)
		            {
		yield return (XmlNode)element;
		            }
	       }

        public static T FromXml<T>(this string sXml)
        {
	           using (var reader = new StringReader(sXml))
		            {
		var serializer = new XmlSerializer(typeof(T));
		                return (T)serializer.Deserialize(reader);
		            }
	        }
	
	#endregion

	public static object ObjectOf<T>(this T arg) => (object)arg;
	
	public static dynamic AsDynamic(this object obj, bool recursive = false)
	{
		var dyn = new ExpandoObject();

		Type GetStaticType<T>(T x) => typeof(T);

		var props = GetStaticType(obj).GetProperties()
									  .Select(p => new { p.Name, Value = recursive ? p.GetValue(obj).AsDynamic(recursive) : p.GetValue(obj) });

		var dict = dyn as IDictionary<string, object>;

		foreach (var prop in props)
		{
			dict.Add(prop.Name, prop.Value);
		}
		
		return dyn;
	}
	
	public static T DynamicClone<T>(this T obj) where T : class => (T) obj.AsDynamic(); 
}

#endregion

#region MyUtils

public static class MyUtils
{
	#region Paths	

	//Internal use
	private static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

	public static string DesktopPath 
	{ 
		get => desktopPath; 
	}

	public static string CDiskPath
	{ 
		get => Path.GetPathRoot(Environment.SystemDirectory); 
	}

	public static string MyQueriesPath
	{ 
		get => @"C:\Users\tcordara\Documents\LINQPad Queries";
	} 

	public static string MyExtensionsPath
	{
		get => @"C:\Users\tcordara\Documents\LINQPad Plugins\Framework 4.6\MyExtensions.FW46.linq";
	}
	
	#endregion

	#region MakeFunc Implementations

	public static Func<T> MakeFunc<T>(Func<T> func) => func;

	public static Func<T, K> MakeFunc<T, K>(Func<T, K> func) => func;

	public static Func<T, K, S> MakeFunc<T, K, S>(Func<T, K, S> func) => func;

	public static Func<T, K, S, R> MakeFunc<T, K, S, R>(Func<T, K, S, R> func) => func;

	public static Func<T, K, S, R, M> MakeFunc<T, K, S, R, M>(Func<T, K, S, R, M> func) => func;

	public static Func<T, K, S, R, M, N> MakeFunc<T, K, S, R, M, N>(Func<T, K, S, R, M, N> func) => func;

	public static Func<T, K, S, R, M, N, O> MakeFunc<T, K, S, R, M, N, O>(Func<T, K, S, R, M, N, O> func) => func;

	public static Func<T, K, S, R, M, N, O, P> MakeFunc<T, K, S, R, M, N, O, P>(Func<T, K, S, R, M, N, O, P> func) => func;

	#endregion
	
	#region MakeAction
	
	public static Action MakeAction(Action action) => action;
	
	public static Action<T> MakeAction<T>(Action<T> action) => action;
	
	public static Action<T, K> MakeAction<T, K>(Action<T, K> action) => action;
	
	#endregion
	
	#region MakeArray
	
	public static T[] MakeArray<T>(params T[] arr) => arr;
	
	public static List<T> MakeList<T>(params T[] arr) => arr.ToList();

	#endregion

	#region MakeTask

	//Bind-alike implementation (!?)
	public static async Task<K> MakeTask<T,K>(Task<T> task, Func<T,K> func)
		=> func(await task);

	#endregion
	
	#region Task-Based
	
	public static async Task<T> WaitSome<T>(TimeSpan span, Task<T> task)
	{
		await Task.Delay(span);
		return await task;
	}

	public static async Task WaitSome(TimeSpan span, Task task)
	{
		await Task.Delay(span);
		await task;
	}

	#endregion
	
	#region Randoms
	
	public static bool RandomBool()
		=> Guid.NewGuid()
		   	   .ToString()
		   	   .ToCharArray()
		       .Where(char.IsNumber)
		   	   .First()
		   	   .Pipe(n => n % 2 == 0);		
	
	public static IEnumerable<string> InfiniteSeq(Seq? config = null)
	{
		//Default: 'LettersAndNumbers'
		Func<char, bool> Config = char.IsLetterOrDigit;

		switch (config)
		{
			case Seq.OnlyNumbers:
				Config = char.IsNumber;
				break;
			
			case Seq.OnlyLetters:
				Config = char.IsLetter;
				break;
			
			case Seq.LettersAndNumbers:
				Config = char.IsLetterOrDigit;
				break;
				
			case Seq.Full:
				Config = c => true;
				break;	
			
			default:
				break;
		}
		
		IEnumerable<string> getLetterOrDigit () => Guid.NewGuid()
												  	   .ToString()
												  	   .ToCharArray()
												  	   .Where(Config)
												  	   .Select(c => c.ToString());

		while (true)
		{
			var digits = getLetterOrDigit();
			foreach (var digit in digits)
			{
				yield return digit;
			}
		}
	}

	#endregion

	#region Enum Declarations

	public enum Seq
	{
		OnlyNumbers,
		OnlyLetters,
		LettersAndNumbers,
		Full
	}

	#endregion

	#region Enums

	public static IEnumerable<T> GetEnums<T>() where T : System.Enum 
		=> Enum.GetValues(typeof(T)).Cast<T>();
	
	public static T ToEnum<T>(this string s) where T : System.Enum 
		=> (T)Enum.Parse(typeof(T), s);
	
	#endregion

	#region Txt Read/Write

	public static IEnumerable<string> ReadTxtFromDesktop(string fileName)
		=> _ReadTxt(fileName, true);


	public static IEnumerable<string> ReadTxt(string fileName)
		=> _ReadTxt(fileName, false);
	
	static IEnumerable<string> _ReadTxt(string fileName, bool fromDesktop)
	{
		string line;
		var path = fromDesktop ? Path.Combine(desktopPath, fileName) : fileName;
		var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

		using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
		{
			while ((line = streamReader.ReadLine()) != null)
				yield return line;
		}
	}

	public static bool WriteTxtToDesktop(IEnumerable<string> lines, string filename = null, bool append = true)
	{
		filename = filename ?? "archivo.txt";

		using (var outputFile = new StreamWriter(Path.Combine(desktopPath, filename), append))
		{
			foreach (string line in lines)
				outputFile.WriteLine(line);
		}
		
		return true;
	}

	public static bool WriteTxt(IEnumerable<string> lines, string filename = null, bool append = true)
	{
		using (var outputFile = new StreamWriter(filename, append))
		{
			foreach (string line in lines)
				outputFile.WriteLine(line);
		}
		
		return true;
	}

	#endregion

	#region JSON Read/Write

	public static Newtonsoft.Json.Linq.JObject ReadJSONObjectFromDesktop(string fileName)
		=> ReadJSONObject(Path.Combine(desktopPath, fileName));

	public static Newtonsoft.Json.Linq.JObject ReadJSONObject(string filePath)
	{
		var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

		using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
		{
			var reader = new JsonTextReader(new StringReader(streamReader.ReadToEnd()));
			return JObject.Load(reader);
		}
	}

	public static Newtonsoft.Json.Linq.JArray ReadJSONArrayFromDesktop(string fileName)
		=> ReadJSONArray(Path.Combine(desktopPath, fileName));

	public static Newtonsoft.Json.Linq.JArray ReadJSONArray(string fileName)
	{
		var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

		using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
		{
			var reader = new JsonTextReader(new StringReader(streamReader.ReadToEnd()));
			return JArray.Load(reader);
		}
	}

	public static void WriteJsonToDesktop(Newtonsoft.Json.Linq.JObject JObj, string fileName)
	{
		using (StreamWriter file = File.CreateText(Path.Combine(desktopPath, fileName)))
		using (JsonTextWriter writer = new JsonTextWriter(file))
		{
			JObj.WriteTo(writer);
		}
	}

	public static void WriteJsonToDesktop(Newtonsoft.Json.Linq.JArray JArray, string fileName)
	{
		using (StreamWriter file = File.CreateText(Path.Combine(desktopPath, fileName)))
		using (JsonTextWriter writer = new JsonTextWriter(file))
		{
			JArray.WriteTo(writer);
		}
	}

	#endregion

	#region XML

	public static string ToXml<T>(T myObj)
	{
		var xsSubmit = new XmlSerializer(typeof(T));

		var settings = new XmlWriterSettings
		{
			Indent = true,
			IndentChars = "  ",
			NewLineChars = "\r\n",
			NewLineHandling = NewLineHandling.Replace
		};

		var xml = "";

		using (var sww = new StringWriter())
		{
			using (XmlWriter writer = XmlWriter.Create(sww, settings))
			{
				xsSubmit.Serialize(writer, myObj);
				xml = sww.ToString(); // Your XML
			}
		}

		return xml;
	}

	public static T FromXml<T>(string sXml)
	{
		try
		{
			using(var reader = new StringReader(sXml))
			{
				var serializer = new XmlSerializer(typeof(T));
				return (T)serializer.Deserialize(reader);
			}		
		}
		catch (Exception)
		{
			throw;
		}
	}

	public static dynamic XMLToDynamic(string xmlData)
	{
		var doc = XDocument.Parse(xmlData);
		string jsonText = JsonConvert.SerializeXNode(doc);
		return JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
	}

	#endregion

	#region File Opener

	public static Process OpenFile(string filePath)
		=> System.Diagnostics.Process.Start(filePath);
	
	public static Process OpenFileFromDesktop(string fileName)
		=> System.Diagnostics.Process.Start(Path.Combine(desktopPath, fileName));


	#endregion

	#region SetTimeOut/Interval

	public static async Task SetIntervalAsync(int milliseconds, TimeSpan timeStop, Action act)
	{
		while (DateTime.Now.TimeOfDay < timeStop)
		{
			act.Invoke();
			await System.Threading.Tasks.Task.Delay(milliseconds);
		}
	}

	//REVISAR IMPLEMENTACION	
	public static async Task SetIntervalAsync(int milliseconds, TimeSpan timeStop, Task task)
	{
		while (DateTime.Now.TimeOfDay < timeStop)
		{
			await task;
			await System.Threading.Tasks.Task.Delay(milliseconds);
		}
	}

	public static async Task SetTimeOutAsync(int millisecondsInterval, TimeSpan timeStop, Action act)
	{
		while (DateTime.Now.TimeOfDay < timeStop)
		{
			await System.Threading.Tasks.Task.Delay(millisecondsInterval);
		}

		await System.Threading.Tasks.Task.Run(act);
	}

	public static async Task SetTimeOutAsync(int millisecondsInterval, TimeSpan timeStop, System.Threading.Tasks.Task act)
	{
		while (DateTime.Now.TimeOfDay < timeStop)
		{
			await System.Threading.Tasks.Task.Delay(millisecondsInterval);
		}

		await act;
	}

	#endregion
	
	#region String Manipulation
	
	public static IEnumerable<string> SplitBy(this string auxs, params char[] separators)
		=> auxs.Split(separators);

	
	public static IEnumerable<string> SplitBy(this string auxs, params string[] separators)
		=> auxs.Split(separators, StringSplitOptions.None);

	public static IEnumerable<IEnumerable<string>> SplitByTab(this IEnumerable<string> rows)
		=> rows.Select(s => s.SplitBy(new char[] { '\t' }));

	public static string CleanFileName(this string fileName)
		=> Path.GetInvalidFileNameChars()
			   .Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
	
	public static string RandomName(int numberOfLetters)
		=> Guid.NewGuid()
			   .ToString()
			   .ToCharArray()
			   .Where(char.IsLetterOrDigit)
			   .Take(numberOfLetters)
			   .Pipe(string.Concat);	

	public static List<List<string>> ToMatrix<T>(this IEnumerable<T> items)
	{
		var matrix = new List<List<string>>();

		var names = items.First().GetType().GetProperties().Select(p => p.Name).ToList();

		matrix.Add(names);

		var values = items.Select(i => i.GetType().GetProperties().Select(p => p.GetValue(i).ToString()).ToList()).ToList();

		matrix.AddRange(values);

		return matrix;
	}

	#endregion
	
	#region Excel Generation
	
	public static class Excel
	{
	
	public static void Generate(IEnumerable<IEnumerable<string>> matrix, string path, bool openGenerated = true)
	{
		var workbook = new HSSFWorkbook();
		var sheet = workbook.CreateSheet();
		int contRow = 0;
		int contCell = 0;

		foreach (var line in matrix)
		{
			var row = sheet.CreateRow(contRow);
			contRow++;
			contCell = 0;

			foreach (var cell in line)
			{
				var auxcell = row.CreateCell(contCell);
				auxcell.SetCellValue(cell);
				contCell++;
			}
		}

		Enumerable.Range(0, sheet.GetRow(0).PhysicalNumberOfCells)
				  .ToList()
				  .ForEach(i => { sheet.AutoSizeColumn(i); GC.Collect(); });

		using (var xfile = new FileStream(path, FileMode.Create, System.IO.FileAccess.Write))
		{
			workbook.Write(xfile);
		}

		"Workbook generated successfully".Dump();		
		
		if(openGenerated)
			OpenFile(path);
	}

	public static void GenerateToDesktop(IEnumerable<IEnumerable<string>> matrix, string fileName)
	{
		Excel.Generate(matrix, Path.Combine(desktopPath, fileName));
	}

	public static DataTable GetDataTableFromSpreadSheet(String Path, int sheetNumber = 0)
	{
		XSSFWorkbook wb;
		XSSFSheet sh;
		String Sheet_name;

		using (var fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
		{
			wb = new XSSFWorkbook(fs);

			Sheet_name = wb.GetSheetAt(sheetNumber).SheetName;  //get first sheet name
		}
		DataTable DT = new DataTable();
		DT.Rows.Clear();
		DT.Columns.Clear();

		// get sheet
		sh = (XSSFSheet)wb.GetSheet(Sheet_name);

		int i = 0;
		while (sh.GetRow(i) != null)
		{
			// add neccessary columns
			if (DT.Columns.Count < sh.GetRow(i).Cells.Count)
			{
				for (int j = 0; j < sh.GetRow(i).Cells.Count; j++)
				{
					DT.Columns.Add("", typeof(string));
				}
			}

			// add row
			DT.Rows.Add();

			// write row value
			for (int j = 0; j < sh.GetRow(i).Cells.Count; j++)
			{
				var cell = sh.GetRow(i).GetCell(j);

				if (cell != null)
				{
					// TODO: you can add more cell types capatibility, e. g. formula
					switch (cell.CellType)
					{
						case NPOI.SS.UserModel.CellType.Numeric:
							DT.Rows[i][j] = sh.GetRow(i).GetCell(j).NumericCellValue;
							//dataGridView1[j, i].Value = sh.GetRow(i).GetCell(j).NumericCellValue;

							break;
						case NPOI.SS.UserModel.CellType.String:
							DT.Rows[i][j] = sh.GetRow(i).GetCell(j).StringCellValue;

							break;
					}
				}
			}

			i++;
		}

		return DT;
		}

	}
	
	#endregion

	#region DB/SQL Related

	public static class DB
	{
		public static string RowsAsInsert<T>(List<T> myObjs, string insertName, bool excludePK = false)
		{
			Func<int, string> stringFormat = (index) => index == 0 ? "'{0}'" : ", '{0}'";

			Func<object, int, string> stringFormatForNulls = (value, index) =>
			{

				if (value == null)
					return index == 0 ? "NULL" : ", NULL";
				else
					return index == 0 ? "{0}" : ", '{0}'";
			};

			Func<int, string> stringFormatFields = (index) => index == 0 ? "{0}" : ", {0}";
			Func<int, string> valuesFormat = (index) => index == 0 ? "({0})" : ", ({0})";

			var first = myObjs.First();
			var fields = first.GetType().GetFields();

			Func<string, int, bool> PKFunc = (s, i) => true;
			Func<FieldInfo, int, bool> PKFuncFieldInfo = (f, i) => true;

			if (excludePK)
			{
				PKFunc = (s, i) => i > 0;
				PKFuncFieldInfo = (s, i) => i > 0;
			}

			var names = fields.Select(f => f.Name.ToLower())
							   .Where(PKFunc) //PRIMARY KEY EXCLUDING
							   .Select((v, i) => string.Format(stringFormatFields(i), v))
							   .Aggregate(new StringBuilder(), (acum, s) => acum.AppendLine(s))
							   .ToString();

			var lines = myObjs.Select(obj => obj.GetType().GetFields()
									.Where(PKFuncFieldInfo) //PRIMARY KEY EXCLUDING
									.Select(f => f.GetValue(obj))
									.Select((v, i) => string.Format(stringFormatForNulls(v, i), v))
									.Aggregate(new StringBuilder(), (acum, s) => acum.Append(s))
									.ToString())
							 .Select((v, i) => string.Format(valuesFormat(i), v))
							 .Aggregate(new StringBuilder(), (acum, s) => acum.AppendLine(s))
							 .ToString();

			return string.Format("Insert into {0} ({1}) Values {2}", insertName, names, lines);
		}
	}
	#endregion
	
	#region Date Related

	public static string DateAsFileName()
		=> string.Concat("_", DateTime.Now.ToString().SplitBy('/').Pipe(s => string.Join("-", s)));

	#endregion

	#region Web

	public static async Task<bool> IsOnline(string url)
	{
		var client = new RestClient(new Uri(url));

		var request = new RestRequest(Method.GET);

		var response = await client.ExecuteTaskAsync(request);

		return response.StatusCode == System.Net.HttpStatusCode.OK;
	}

	#endregion

	#region SOAP Requests

	public static XmlDocument ExecuteXmlPostRequest(string sXmlRequest, string url)
	{
		var requestXml = new XmlDocument();
		requestXml.LoadXml(sXmlRequest);

		// build XML request 
		var httpRequest = HttpWebRequest.Create(url);
		httpRequest.Method = "POST";
		httpRequest.ContentType = "text/xml";

		// set appropriate headers
		using (var requestStream = httpRequest.GetRequestStream())
		{
			requestXml.Save(requestStream);
		}

		using (var response = (HttpWebResponse)httpRequest.GetResponse())
		{
			using (var responseStream = response.GetResponseStream())
			{
				// may want to check response.StatusCode to
				// see if the request was successful
				var responseXml = new XmlDocument();
				responseXml.Load(responseStream);
				return responseXml;
			}
		}
	}

	public static async Task<List<XmlDocument>> ExecuteManyXmlRequests(int number, string requestAsXml, string url)
	{
		var tasks = Enumerable.Range(0, number).Select(e => Task.Run(() => MyUtils.ExecuteXmlPostRequest(requestAsXml, url)));

		var results = await Task.WhenAll(tasks);

		return results.ToList();
	}
	
	public static async Task<XmlDocument> ExecuteXmlPostRequestAsync(string _url, XmlDocument xmlRequest, Dictionary<string, string> headers = null)
	{
		var httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
		httpWebRequest.ContentType = "text/xml";
		httpWebRequest.Method = "POST";

		if (headers != null)
		{
			foreach (var header in headers)
			{
				httpWebRequest.Headers.Add(header.Key, header.Value);
			}
		}

		using (var stream = await Task.Factory.FromAsync(httpWebRequest.BeginGetRequestStream,
																  httpWebRequest.EndGetRequestStream, null))
		{
			var requestAsBytes = Encoding.Default.GetBytes(xmlRequest.OuterXml);

			await stream.WriteAsync(requestAsBytes, 0, requestAsBytes.Length);
		}

		using (var responseObject = await Task.Factory.FromAsync(httpWebRequest.BeginGetResponse,
																			httpWebRequest.EndGetResponse, httpWebRequest))
		{
			var responseXml = new XmlDocument();
			responseXml.Load(responseObject.GetResponseStream());
			return responseXml;
		}
	}

	#endregion

	#region Rest Requests
	
	public static class Http
	{
		public static async Task<IRestResponse> Post(string url, object body = null, Dictionary<string, object> parameters = null, Dictionary<string, string> headers = null)
		{
			var client = new RestClient(new Uri(url));

			var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };

			if (headers != null)
			{
				foreach (var header in headers)
				{
					request.AddHeader(header.Key, header.Value);
				}
			}

			if (parameters != null)
			{
				foreach (var parameter in parameters)
				{
					request.AddParameter(parameter.Key, parameter.Value, ParameterType.HttpHeader);
				}
			}

			if (body != null)
				request.AddBody(body);

			return await client.ExecuteTaskAsync(request);
		}

		public static async Task<IRestResponse> Post(string access_token, string url, object parameter)
		{
			var client = new RestClient(new Uri(url));

			var request = new RestRequest(Method.POST);

			request.AddHeader("Content-Type", "application/json");

			request.AddParameter("Authorization", "Bearer " + access_token, ParameterType.HttpHeader);
			request.AddParameter("application/json", parameter, ParameterType.RequestBody);

			return await client.ExecuteTaskAsync(request);
		}

		public static async Task<IRestResponse> Get(string access_token, string url, object parameter)
		{
			var client = new RestClient(new Uri(url));

			var request = new RestRequest(Method.GET);

			request.AddHeader("Content-Type", "application/json");

			request.AddParameter("Authorization", "Bearer " + access_token, ParameterType.HttpHeader);
			request.AddParameter("application/json", parameter, ParameterType.RequestBody);

			return await client.ExecuteTaskAsync(request);
		}
		
		public static async Task<IRestResponse> Get(string url)
		{
			var client = new RestClient(new Uri(url));

			var request = new RestRequest(Method.GET);

			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("application/json", ParameterType.RequestBody);

			return await client.ExecuteTaskAsync(request);
		}
	}

	#endregion

	#region Is Prime

	public static bool IsPrime(int n)
		=> n > 1 ? Enumerable.Range(1, n)
							 .Where(x => n % x == 0)
							 .SequenceEqual(new [] { 1, n }) 
				 : false;

	#endregion
	
	#region IO

	public static class IO
	{
		public static List<string> GetDirectoriesRecursive(string parent)
		{
			var directories = new List<string>();
			GetDirectoriesRecursive(directories, parent);
			return directories;
		}

		public static void GetDirectoriesRecursive(List<string> directories, string parent)
		{
			directories.Add(parent);
			foreach (string child in GetAuthorizedDirectories(parent))
				GetDirectoriesRecursive(directories, child);
		}

		public static string[] GetAuthorizedDirectories(string dir)
		{
			try { return Directory.GetDirectories(dir); }
			catch (UnauthorizedAccessException) { return new string[0]; }
		}

		public static string[] GetAuthorizedFiles(string dir)
		{
			try { return Directory.GetFiles(dir); }
			catch (UnauthorizedAccessException) { return new string[0]; }
		}

	}

	#endregion
	
	#region MakeExceptionable

	public static Func<(T element, Exception exception)> MakeExceptionable<T>(Func<T> func)
	{
		(T element, Exception exception) f()
		{
			try
			{
				return (func(), null);
			}
			catch (Exception ex)
			{
				return (default(T), ex);
			}
		};

		return f;
	}

	#endregion

	#region OpenBrowser

	public static void OpenBrowser(string url)
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			var p = new Process();
			p.StartInfo = new ProcessStartInfo(url)
			{
				UseShellExecute = true
			};
			p.Start();
		}
		else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		{
			Process.Start("xdg-open", url);  // Works ok on linux
		}
		else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		{
			Process.Start("open", url); // Not tested
		}
		else
		{
		
    	}
	}

	#endregion
	
	public static K Mute<T, K>(this T element, Func<K> func, Action<T, K> fx)
	{
		var seed = func();
		fx(element, seed);
		return seed;
	}
}

#endregion

#region DateTimeSpan Class

//DateTimeSpan
//href: https://stackoverflow.com/questions/4638993/difference-in-months-between-two-dates

public struct DateTimeSpan
{
	private readonly int years;
	private readonly int months;
	private readonly int days;
	private readonly int hours;
	private readonly int minutes;
	private readonly int seconds;
	private readonly int milliseconds;

	public DateTimeSpan(int years, int months, int days, int hours, int minutes, int seconds, int milliseconds)
	{
		this.years = years;
		this.months = months;
		this.days = days;
		this.hours = hours;
		this.minutes = minutes;
		this.seconds = seconds;
		this.milliseconds = milliseconds;
	}

	public int Years { get { return years; } }
	public int Months { get { return months; } }
	public int Days { get { return days; } }
	public int Hours { get { return hours; } }
	public int Minutes { get { return minutes; } }
	public int Seconds { get { return seconds; } }
	public int Milliseconds { get { return milliseconds; } }

	enum Phase { Years, Months, Days, Done }

	public static DateTimeSpan CompareDates(DateTime date1, DateTime date2)
	{
		if (date2 < date1)
		{
			var sub = date1;
			date1 = date2;
			date2 = sub;
		}

		DateTime current = date1;
		int years = 0;
		int months = 0;
		int days = 0;

		Phase phase = Phase.Years;
		DateTimeSpan span = new DateTimeSpan();
		int officialDay = current.Day;

		while (phase != Phase.Done)
		{
			switch (phase)
			{
				case Phase.Years:
					if (current.AddYears(years + 1) > date2)
					{
						phase = Phase.Months;
						current = current.AddYears(years);
					}
					else
					{
						years++;
					}
					break;
				case Phase.Months:
					if (current.AddMonths(months + 1) > date2)
					{
						phase = Phase.Days;
						current = current.AddMonths(months);
						if (current.Day < officialDay && officialDay <= DateTime.DaysInMonth(current.Year, current.Month))
							current = current.AddDays(officialDay - current.Day);
					}
					else
					{
						months++;
					}
					break;
				case Phase.Days:
					if (current.AddDays(days + 1) > date2)
					{
						current = current.AddDays(days);
						var timespan = date2 - current;
						span = new DateTimeSpan(years, months, days, timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
						phase = Phase.Done;
					}
					else
					{
						days++;
					}
					break;
			}
		}

		return span;
	}
}

#endregion

#region ClassBuilder 
/*
public class ClassBuilder
{
	AssemblyName asemblyName;

	public ClassBuilder(string ClassName)
	{
		this.asemblyName = new AssemblyName(ClassName);
	}

	public object CreateObject(string[] PropertyNames, Type[] Types = null)
	{
		if (Types != null && PropertyNames.Length != Types.Length)
		{
			Console.WriteLine("The number of property names should match their corresponding types number");
		}

		TypeBuilder DynamicClass = this.CreateClass();
		this.CreateConstructor(DynamicClass);
		for (int ind = 0; ind < PropertyNames.Count(); ind++)
		{
			CreateProperty(DynamicClass, PropertyNames[ind], Types != null ? Types[ind] : typeof(string));
		}

		Type type = DynamicClass.CreateType();

		return Activator.CreateInstance(type);
	}

	public object CreateObjectWithProps(Dictionary<string, string> props)
	{
		TypeBuilder DynamicClass = this.CreateClass();
		this.CreateConstructor(DynamicClass);
		
		foreach (var prop in props)
		{
			CreateProperty(DynamicClass, prop.Key, typeof(string));
		}

		Type type = DynamicClass.CreateType();

		var instance = Activator.CreateInstance(type);
		
		instance.SetProps(props.Select(p => p.Value));
		
		return instance;
	}

	private TypeBuilder CreateClass()
	{
		AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(this.asemblyName, AssemblyBuilderAccess.Run);
		ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
		TypeBuilder typeBuilder = moduleBuilder.DefineType(this.asemblyName.FullName
							, TypeAttributes.Public |
							TypeAttributes.Class |
							TypeAttributes.AutoClass |
							TypeAttributes.AnsiClass |
							TypeAttributes.BeforeFieldInit |
							TypeAttributes.AutoLayout
							, null);
		return typeBuilder;
	}

	private void CreateConstructor(TypeBuilder typeBuilder)
	{
		typeBuilder.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
	}

	private void CreateProperty(TypeBuilder typeBuilder, string propertyName, Type propertyType)
	{
		FieldBuilder fieldBuilder = typeBuilder.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);

		PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(propertyName, System.Reflection.PropertyAttributes.HasDefault, propertyType, null);
		MethodBuilder getPropMthdBldr = typeBuilder.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
		ILGenerator getIl = getPropMthdBldr.GetILGenerator();

		getIl.Emit(OpCodes.Ldarg_0);
		getIl.Emit(OpCodes.Ldfld, fieldBuilder);
		getIl.Emit(OpCodes.Ret);

		MethodBuilder setPropMthdBldr = typeBuilder.DefineMethod("set_" + propertyName,
			  MethodAttributes.Public |
			  MethodAttributes.SpecialName |
			  MethodAttributes.HideBySig,
			  null, new[] { propertyType });

		ILGenerator setIl = setPropMthdBldr.GetILGenerator();
		Label modifyProperty = setIl.DefineLabel();
		Label exitSet = setIl.DefineLabel();

		setIl.MarkLabel(modifyProperty);
		setIl.Emit(OpCodes.Ldarg_0);
		setIl.Emit(OpCodes.Ldarg_1);
		setIl.Emit(OpCodes.Stfld, fieldBuilder);

		setIl.Emit(OpCodes.Nop);
		setIl.MarkLabel(exitSet);
		setIl.Emit(OpCodes.Ret);

		propertyBuilder.SetGetMethod(getPropMthdBldr);
		propertyBuilder.SetSetMethod(setPropMthdBldr);
	}
}

public static class ClassBuilderExtensions
{
	public static void SetProps<T>(this T obj, IEnumerable<T> propsValues)
	{
				obj.GetType()
				  .GetProperties()
				  .Zip(propsValues, (prop, result) =>
				  {
				  		prop.SetValue(obj, result);
						return string.Empty;
				  })
				  .ToList();
	}

	public static K SetFields<T, K>(this T item, K instance)
	{
		var fields = item.GetType().GetFields();
		var instanceType = instance.GetType();

		foreach (var field in fields)
		{
			var fieldIns = instanceType.GetField(field.Name);
			if (fieldIns != null)
			{
				fieldIns.SetValue(instance, field.GetValue(item));
			}
		}

		return instance;
	}
}
*/
#endregion

#region Task Counter

public static class TaskCounter
{
	public static async Task<TimedResult<T>> Run<T>(string name, Task<T> task)
	{
		var stopwatch = new Stopwatch();
		stopwatch.Start();
		var result = await task;
		stopwatch.Stop();

		return new TimedResult<T>()
		{
			Elapsed = stopwatch.Elapsed,
			Result = result,
			Name = name
		};
	}
	
	public class TimedResult<T>
	{
		public TimeSpan Elapsed { get; set; }
		public T Result { get; set; }
		public string Name { get; set; }
	}
}

#endregion
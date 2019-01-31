<Query Kind="Program">
  <Reference Relative="..\..\net45\Newtonsoft.Json.dll">&lt;MyDocuments&gt;\net45\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Entity.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Reflection.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Reflection.Emit.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <NuGetReference>NPOI</NuGetReference>
  <NuGetReference>RestSharp</NuGetReference>
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>NPOI.HSSF.UserModel</Namespace>
  <Namespace>RestSharp</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>System.Dynamic</Namespace>
</Query>

void Main()
{
	
}

#region MyExtensions

public static class MyExtensions
{
	#region Powerful one-liners

	/// <summary>
	/// Projects a value into a function invocation
	/// </summary>
	public static K Project<T, K>(this T obj, Func<T, K> func) => func.Invoke(obj);

	public static T[] AsArray<T>(this T obj) => new T[] { obj };	
	
	public static dynamic[] AsArrayDynamicParams(params dynamic[] elements) => elements;

	public static string ToNullString<T>(this T obj) => obj?.ToString() ?? "NULL";

	/// <summary>
	/// Reverse bool value
	/// </summary>
	public static bool ReverseBool(this bool boolean) => !boolean;

	/// <summary>
	/// Calls an action over a variable and the returns that variable
	/// </summary>
	public static T Call<T>(this T obj, Action<T> act) { act.Invoke(obj); return obj; }

	/// <summary>
	/// Pipes 1 functions
	/// </summary>
	public static K Pipe<T, K>(this T obj, Func<T, K> fun) => fun(obj);

	/// <summary>
	/// Pipes 2 functions
	/// </summary>
	public static S Pipe<T, K, S>(this T obj, Func<T, K> fun1, Func<K, S> fun2) => fun2(fun1(obj));
	
	/// <summary>
	/// Pipes 3 functions
	/// </summary>
	public static R Pipe<T, K, S, R>(this T obj, Func<T, K> fun1, Func<K, S> fun2, Func<S, R> fun3) => fun3(fun2(fun1(obj)));

	/// <summary>
	/// Pipes 4 functions
	/// </summary>
	public static G Pipe<T, K, S, R, G>(this T obj, Func<T, K> fun1, Func<K, S> fun2, Func<S, R> fun3, Func<R, G> fun4) => fun4(fun3(fun2(fun1(obj))));

	/// <summary>
	/// Pipes 5 functions
	/// </summary>
	public static H Pipe<T, K, S, R, G, H>(this T obj, Func<T, K> fun1, Func<K, S> fun2, Func<S, R> fun3, Func<R, G> fun4, Func<G, H> fun5) => fun5(fun4(fun3(fun2(fun1(obj)))));

	#endregion	

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

	public static IOrderedEnumerable<IGrouping<char, string>> FieldsByName<T>(this T obj)
	{
		return obj.GetType()
				  .GetFields()
				  .Select(f => f.Name)
				  .GroupBy(f => f[0])
				  .OrderBy(f => f.Key);
	}

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
	{
		return auxs.Aggregate(new StringBuilder(), (builder, s) => builder.Append(s)).ToString();
	}

	#endregion
}

#endregion

#region MyUtils

public static class MyUtils
{
	#region Paths	

	//Internal use
	private static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

	public static string DesktopPath { get { return desktopPath; } }

	public static string CDiskPath { get { return Path.GetPathRoot(Environment.SystemDirectory); } }
	
	public static string MyQueriesPath { get { return @"C:\Users\tcordara\Documents\LINQPad Queries"; } }

	public static string MyExtensionsPath
	{
		get 
		{	
			return @"C:\Users\tcordara\Documents\LINQPad Plugins\Framework 4.6\MyExtensions.FW46.linq";
		}
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
	
	public static T[] MakeArray<T>(params T[] arr)
	{
		return arr;
	}
	
	public static List<T> MakeList<T>(params T[] arr)
	{
		return arr.ToList();
	}

	#endregion

	#region MakeTask

	//Bind-alike implementation (!?)
	public static async Task<K> MakeTask<T,K>(Task<T> task, Func<T,K> func)
	{
		var result = await task;
		return func(result);
}

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
	{
		return Guid.NewGuid()
		           .ToString()
				   .ToCharArray()
				   .Where(char.IsNumber)
				   .First()
				   .Project(n => n % 2 == 0);		
	}
	
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
		
		var getLetterOrDigit = MakeFunc(() => Guid.NewGuid()
												  .ToString()
												  .ToCharArray()
												  .Where(Config)
												  .Select(c => c.ToString()));

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

	public static IEnumerable<T> GetEnums<T>()
	{
		var type = typeof(T);
		if (!type.IsEnum)
		{
			throw new ArgumentException("The type is not and enum type");
		}

		return Enum.GetValues(type).Cast<T>();
	}
	
	public static T ToEnum<T>(this string s) where T : struct
	{
		var type = typeof(T);
		if (!type.IsEnum)
		{
			throw new ArgumentException("The type is not and enum type");
		}
		
		return (T)Enum.Parse(typeof(T), s);
	}

	public static T ToEnum2<T>(this string sValue) where T : struct
	{
		T option = default(T);
		int intEnumValue;
		if (Int32.TryParse(sValue, out intEnumValue))
		{
			if (Enum.IsDefined(typeof(T), intEnumValue))
			{
				if (Enum.TryParse(sValue, out option))
				{
					return option;
				}
			}
		}

		return option;
	}
	#endregion

	#region Txt Read/Write

	public static IEnumerable<string> ReadTxtFromDesktop(string fileName)
	{
		return _ReadTxt(fileName, true);
	}

	public static IEnumerable<string> ReadTxt(string fileName)
	{
		return _ReadTxt(fileName, false);
	}

	private static IEnumerable<string> _ReadTxt(string fileName, bool fromDesktop)
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

	public static void WriteTxtToDesktop(IEnumerable<string> lines, string filename = null, bool append = true)
	{
		filename = filename ?? "archivo.txt";

		using (var outputFile = new StreamWriter(Path.Combine(desktopPath, filename), append))
		{
			foreach (string line in lines)
				outputFile.WriteLine(line);
		}
	}

	public static void WriteTxt(IEnumerable<string> lines, string filename = null, bool append = true)
	{
		using (var outputFile = new StreamWriter(filename, append))
		{
			foreach (string line in lines)
				outputFile.WriteLine(line);
		}
	}

	#endregion

	#region JSON Read/Write

	public static Newtonsoft.Json.Linq.JObject ReadJSONObjectFromDesktop(string fileName)
	{
		var fileStream = new FileStream(Path.Combine(desktopPath, fileName), FileMode.Open, FileAccess.Read);

		using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
		{
			var reader = new JsonTextReader(new StringReader(streamReader.ReadToEnd()));
			return JObject.Load(reader);
		}
	}

	public static Newtonsoft.Json.Linq.JArray ReadJSONArrayFromDesktop(string fileName)
	{
		var fileStream = new FileStream(Path.Combine(desktopPath, fileName), FileMode.Open, FileAccess.Read);

		using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
		{
			var reader = new JsonTextReader(new StringReader(streamReader.ReadToEnd()));
			return JArray.Load(reader);
		}
	}

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

	public static T FromXML<T>(string sXml)
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

	public static void OpenFile(string filePath)
	{
		System.Diagnostics.Process.Start(filePath);
	}

	public static void OpenFileFromDesktop(string fileName)
	{
		System.Diagnostics.Process.Start(Path.Combine(desktopPath, fileName));
	}

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
	{
		return auxs.Split(separators);
	}
	
	public static IEnumerable<string> SplitBy(this string auxs, params string[] separators)
	{
		return auxs.Split(separators, StringSplitOptions.None);
	}

	public static IEnumerable<IEnumerable<string>> SplitByTab(this IEnumerable<string> rows)
	{
		return rows.Select(s => s.SplitBy(new char[] { '\t' }));
	}

	public static string CleanFileName(this string fileName)
	{
		return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
	}
	
	public static string RandomName(int numberOfLetters)
	{
		return Guid.NewGuid().ToString().ToCharArray().Where(c => char.IsLetterOrDigit(c)).Take(numberOfLetters).Project(string.Concat);	
	}

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
	
	public static void GenerateExcel(IEnumerable<IEnumerable<string>> matrix, string path)
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

		var msj = "Workbook generated successfully";		
		msj.Dump();
		
		OpenFile(path);
	}

	public static void GenerateExcelToDesktop(IEnumerable<IEnumerable<string>> matrix, string fileName)
	{
		var path = Path.Combine(desktopPath, fileName);
		GenerateExcel(matrix, path);
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
	{
		return string.Concat("_", DateTime.Now.ToString().SplitBy('/').Project(s => string.Join("-", s)));
	}

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
	
	#endregion
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
	public static List<string> SetProps<T>(this T obj, IEnumerable<string> propsName)
	{
		return obj.GetType()
				  .GetProperties()
				  .Zip(propsName, (prop, result) =>
				  {
				  		prop.SetValue(obj, result);
						return string.Format("prop: {0}, value: {1}", prop.Name, result);
				  })
				  .ToList();
	}
}
#endregion

#region Tasker

public static class Tasker
{
	#region Class declarations

	public enum Do
	{
		Create,
		Move
	}

	public enum Destination
	{
		DONE,
		REMOVED,
		TESTING
	}

	public class CreatorArgs
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public IEnumerable<string> Description { get; set; }
		public Meta MetaObj { get; set; }

		public CreatorArgs() { }

		public CreatorArgs(string id, string name, IEnumerable<string> description, Meta metaobj)
		{
			ID = id;
			Name = name;
			Description = description;
			MetaObj = metaobj;
		}

		public string FolderName { get => ID + " - " + Name; }

		public string TaskName { get => "Task " + ID + ".txt"; }
	}

	public class Meta
	{
		public DateTime Start { get; set; }
		public string Client { get; set; }
		public string Leader { get; set; }
		public DateTime? End { get; set; }

		public TimeSpan? Lapsus { get => End - Start; }
	}

	public static class Paths
	{
		public static string Tasks_Folder = MyUtils.DesktopPath + "/ETIDATA/Tasks";

		public static string DONE_Folder = MyUtils.DesktopPath + "/ETIDATA/Tasks/DONE";
	}

	#endregion

	#region Methods

	public static CreatorArgs MakeCreator(string ID, string Name, string Leader)
	{
		return new Tasker.CreatorArgs()
		{
			ID = ID,
			Name = Name,
			Description = MyUtils.ReadTxtFromDesktop("description.txt"),
			MetaObj = new Tasker.Meta() { Start = DateTime.Now, Client = "ETI", Leader = Leader }
		};
	}

	public static void Create(string ID, string Name, string Leader = "Tebi")
	{
		Create(MakeCreator(ID, Name, Leader));
	}

	public static void Create(CreatorArgs creator)
	{
		#region Implementation

		var directoryName = Path.Combine(Paths.Tasks_Folder, creator.FolderName);

		if (Directory.Exists(directoryName))
		{
			"Directory already exists!".Dump();
		}
		else
		{
			//Task folder
			Directory.CreateDirectory(directoryName);

			var txtName = string.Concat(directoryName, "/", creator.TaskName);
			var metaTxtName = string.Concat(directoryName, "/", "meta.txt");

			var separator = Enumerable.Range(0, 60)
									   .Select(r => "*")
									   .Aggregate(new StringBuilder(), (builder, s) => builder.Append(s))
									   .ToString()
									   .Project(r => string.Concat("/", r, "/"));

			var items = new List<string>();

			var description = creator.Description.All(string.IsNullOrEmpty) ? "*No Description*".AsArray().ToList() : creator.Description;

			items.AddRange(description);
			
			var taskUrl = "https://efficienttech.atlassian.net/browse/" + creator.ID; 
			
			items.AddRange(new string[]{string.Empty, "Url: ",taskUrl, string.Empty});

			items.AddRange(new string[] { string.Empty, separator, string.Empty, "Status: ", string.Empty });

			//Task txt
			MyUtils.WriteTxt(items, txtName);

			//Meta txt
			MyUtils.WriteTxt(creator.MetaObj.Project(JsonConvert.SerializeObject).AsArray(), metaTxtName);

			MyUtils.OpenFile(txtName);

			"Success!".Dump();
		}

		#endregion
	}

	public static void Move(string ID)
	{
		#region Implementation

		var destinationFolder = Paths.DONE_Folder;

		var folder = new DirectoryInfo(Paths.Tasks_Folder).GetDirectories().Where(d => d.Name.StartsWith(ID)).FirstOrDefault();

		if (folder != null)
		{
			var metaPath = string.Concat(folder.FullName, @"\meta.txt");

			if (File.Exists(metaPath))
			{
				var metaString = MyUtils.ReadTxt(metaPath).FirstOrDefault();
				var meta = JObject.Parse(metaString).ToObject<Meta>();

				meta.End = DateTime.Now;

				//Modificar el archivo 'meta', agregándole el 'End' date
				MyUtils.WriteTxt(JsonConvert.SerializeObject(meta).ToString().AsArray(), metaPath, false);
			}

			var newPath = string.Concat(destinationFolder, @"\", folder.Name);

			//Para evitar IO Exceptions
			Thread.Sleep(100);

			//Mover la carpeta a 'Tasks/DONE'
			Directory.Move(folder.FullName, newPath);

			"Success!".Dump();

		}
		else
		{
			"Folder doesnt exist!".Dump();
		}

		#endregion
	}

	#endregion
}

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
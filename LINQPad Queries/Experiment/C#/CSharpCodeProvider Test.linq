<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.CSharp.dll</Reference>
</Query>

void Main()
{
	var code = @"
    	public class Abc {
      	 	public string Get() { return Nombre; }
	   
	   		public string Nombre { get; set; }
    	}
	";

	var options = new System.CodeDom.Compiler.CompilerParameters()
	{
		GenerateExecutable = false,
		GenerateInMemory = false
	};

	var provider = new Microsoft.CSharp.CSharpCodeProvider();
	var compile = provider.CompileAssemblyFromSource(options, code);

	var type = compile.CompiledAssembly.GetType("Abc");
	var abc = Activator.CreateInstance(type);

	type.GetProperty("Nombre").SetValue(abc, "Juan", null);
	var method = type.GetMethod("Get");
	var result = method.Invoke(abc, null);

	Console.WriteLine(result);
}

// Define other methods and classes here

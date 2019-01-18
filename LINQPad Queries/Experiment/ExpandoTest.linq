<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.Runtime.dll</Reference>
</Query>

void Main()
{
var dict = new Dictionary<string, object> { { "Property", DateTime.Now } };
dict.Add("Property2", DateTime.Now);
dict.Add("Property3", DateTime.Now);


var eo = new System.Dynamic.ExpandoObject();
var eoColl = (ICollection<KeyValuePair<string,object>>)eo;

foreach (var kvp in dict)
{
    eoColl.Add(kvp);
}

dynamic eoDynamic = eo;

eo.Dump();
}

// Define other methods and classes here

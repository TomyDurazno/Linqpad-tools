<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Dynamic.Runtime.dll</Reference>
</Query>

static void Main()
{
  dynamic d = new Duck();
  d.Quack();                  // Quack method was called
  d.Waddle();  
  
 // d.Run = () =>{Console.WriteLine("Hey")};
  // Waddle method was called
}

public class Duck : System.Dynamic.DynamicObject
{
  public override bool TryInvokeMember (
    System.Dynamic.InvokeMemberBinder binder, object[] args, out object result)
  {
    Console.WriteLine (binder.Name + " method was called");
    result = null;
    return true;
  }
}
// Define other methods and classes here

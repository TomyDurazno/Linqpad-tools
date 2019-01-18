<Query Kind="Program">
  <Output>DataGrids</Output>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
</Query>

void Main()
{

	var nums = AllThePositiveInteger(Enumerable.Range(0, 100000000)
	.Select(v => new System.Numerics.BigInteger(v)))
	.Aggregate((x,y) => x + y)
	.Dump();

}

static IEnumerable<System.Numerics.BigInteger> AllThePositiveInteger(
  IEnumerable<System.Numerics.BigInteger> sourceIntegers)
{
  foreach(var value in sourceIntegers)
    yield return value;
}
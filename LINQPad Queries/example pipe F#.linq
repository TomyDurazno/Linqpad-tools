<Query Kind="FSharpProgram" />

seq { for x in 1 .. 10 -> x }
|> Seq.map(fun n -> n * 2) 
|> Seq.filter(fun n -> n > 5) 
|> Enumerable.Sum
|> Console.WriteLine
<Query Kind="FSharpProgram" />

//Lists (FSharp Lists)

let a = [1; 2; 3]

let b = [1..10]

let c = [ for i = 1 to 10 do yield i + 2 ]

//Expensive!
let d = [1; 2] @ [3; 4]

//Agregar un elemento a la lista en el primer lugar
let e = 3::d

let f = match a with
       | [] -> 0
       | [x] -> 0
       | h::t -> h

f |> Dump
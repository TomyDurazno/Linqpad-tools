<Query Kind="FSharpProgram" />

//Recursion Patterns
let sumarhasta5 a =
    let rec aux n = 
        if n > 5 then
            n
        else
            aux (n + 1)
    aux a

//sumarhasta5 1 |> Dump |> ignore   

//Pattern Matching
let c = match a with 
        | Some x -> (x + 1)
        | None x -> 0

let d = match a with 
        | 1 -> "one"
        | 2 -> "two"
        | _ -> "nose"
        
let e = (1, 2)

let f = match e with
        | (0, x) -> x
        | (1, x) -> x
        | _ -> 0

let g = match e with
        | x when x = 5 -> x
        | x when x <> 5 -> x
        | _ -> 0

f |> Dump

g |> Dump



     
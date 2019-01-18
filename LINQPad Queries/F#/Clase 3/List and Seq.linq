<Query Kind="FSharpProgram" />

let b = [1; 2; 3; 4]

let c = List.map(fun x -> x + 1) b

let d = b |> List.map(fun x -> (x + 1).ToString())
    
//let e = List.reduce (fun acc x -> x + acc) b

let f = List.fold (fun acc x -> acc + x) "" d

let g =
        let builder = new StringBuilder()
        c
        |> List.fold (fun (acc:StringBuilder) x -> acc.Append(x)) builder

//g.ToString() |> Dump |> ignore

let e = [[1;2]; [3;4]]

let aa =
        e
        |> List.collect (fun x -> x)
        
aa |> Dump |> ignore

let bb =
    List.init 10 (fun x -> x * 2)
    
bb |> Dump |> ignore
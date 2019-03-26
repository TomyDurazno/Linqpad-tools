<Query Kind="FSharpProgram" />

let lastelement (list:'a list): 'a option =
    let rec getLast l =
        match l with   
            | [] -> None 
            | [x] -> Some x
            | _::ls -> getLast ls //(ls.Call(fun x -> x.Dump()))

    getLast list
    
let reverse list =
    let rec rev list acc=
        match list with
            | [] -> acc
            | [x] -> x::acc
            | head::tail -> rev tail (head::acc)
     
    rev list []     

let dumper a =
    a.Call(fun x -> x.Dump())

let encoding list =
    let rec encode list (acum: (int * 'b) list) cont =
        match list with
             | [] -> acum
             | [x] -> if x = snd acum.Head then encode [] acum (cont + 1)  
                                                else encode [] ((cont,x)::acum) 1 
             | a::(b::list2) -> if a = b then encode (b::list2) acum (cont + 1) 
                                            else encode (b::list2) ((cont,a)::acum) 1 
    
    encode list [] 1 |> reverse
    
let ``Last element`` () =
    let result1 = lastelement [1; 3; 5; 9]
    let b1 = (result1.Value.Equals 9)
    let result2 = lastelement []
    let b2 = (result2.IsNone)
    b1 && b2

let ``Reverse a list`` () =
    let result1 = reverse [1; 2; 3; 5; 11]
    let check1 = [11; 5; 3; 2; 1]
    let compare1 = List.compareWith (( - )) result1 check1
    compare1.Equals 0

let ``Run length encoding`` () =
    let result1 = encoding ["a";"a";"a";"a";"b";"c";"c";"a";"a";"d";"e";"e";"e";"e"]
    let check1 = [(4, "a"); (1, "b"); (2, "c"); (2, "a"); (1, "d"); (4, "e")]
    let compare1 = (result1, check1) ||> List.compareWith (fun x y -> if x = y then 0 else 1)
    compare1.Equals 0

//``Last element`` () |> Dump
//``Reverse a list`` () |> Dump
//``Run length encoding`` () |> Dump
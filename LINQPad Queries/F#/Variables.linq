<Query Kind="FSharpProgram" />

type VirtualConsole () =
    let mutable printed = ""
    member this.Printed
        with get() = printed
        and set(value) = printed <- value
    member this.Log(str:string) =
        this.Printed <- str
        true

let print (console:VirtualConsole) valor =
    console.Log(valor)

let parse (value: System.String) =
    let valueRef = ref 0
    Int32.TryParse(value, valueRef) |> ignore
    !valueRef

let fizzBuzz (values: int list) =

    let divide3 n = n % 3 = 0 
    let divide5 n = n % 5 = 0 
    let divide15 n = divide3 n && divide5 n

    let getMessage n = if divide15 n then "FizzBuzz" else
                            if divide3 n then "Fizz" else 
                                if divide5 n then "Buzz" else 
                                    n.ToString()

    let result = new ResizeArray<string>()
    
    for i in values do
        result.Add(getMessage i)       
    result

let big (values: string list) =
    let mutable (cont:Int64) = 0L
    for i in values do
        cont <- cont + Int64.Parse(i)
    cont   

let ``Dependency`` () =
    let console = new VirtualConsole()
    print console "Hola mundo"
    let check = (console.Printed = "Hola mundo")
    check

let calculadora value1 value2 (operacion:string) 
    (sumador: int -> int -> int) (restador: int -> int -> int) (multiplicador:int -> int -> int) (divisionador: int -> int -> double) =

    let asDouble (f: 'a -> 'b -> 'c) = (fun a b -> f a b |> Convert.ToDouble)
    
    let action =  [|
                    "+", asDouble sumador;
                    "-", asDouble restador; 
                    "*", asDouble multiplicador; 
                    "/", asDouble divisionador
                  |] 
                  |> Array.tryFind (fun t -> (fst t) = operacion)
    
    if action.IsSome then (snd action.Value) value1 value2 else System.Double.MinValue  

//Tests   
let ``Parse Int`` () =
        let input = "a"
        let result1 = parse input
        let check1 = result1 = 0
        let input2 = "5"
        let result2 = parse input2
        let check2 = result2 = 5
        check2 && check1
  
let ``FizzBuzz`` () =
        let input = List.init 20 (id)
        let result = fizzBuzz input
        let testList = ["FizzBuzz";"1"; "2"; "Fizz"; "4"; "Buzz"; "Fizz"; "7"; "8"; "Fizz"; "Buzz"; "11"; "Fizz"; "13"; "14"; "FizzBuzz"; "16"; "17"; "Fizz"; "19";]
        let checkf = List.compareWith (fun x y -> String.Compare(x, y)) (List.ofSeq(result)) testList |> fun x -> x = 0
        checkf  
        
let ``Calculadora`` () =
        let sumador x y = x + y
        let restador x y = x - y
        let multiplicador x y = x * y
        let divisionador x y = double x / double y
        let result1 = calculadora 1 2 "+" sumador restador multiplicador divisionador
        let check1 = result1.ToString() = "3"
        let result2 = calculadora 1 2 "/" sumador restador multiplicador divisionador
        let check2 = result2.ToString() = "0.5"
        //output.WriteLine(result2.ToString())
        check1 && check2
    
    
let ``Big`` () =
    let input = ["1000000001"; "1000000002"; "1000000003"; "1000000004"; "1000000005"]
    let result = big input
    let check = (5000000015L - result) = 0L
    check

``Parse Int``() |> Dump |> ignore    
Dependency() |> Dump |> ignore            
FizzBuzz() |> Dump |> ignore      
Big() |> Dump |> ignore    
Calculadora() |> Dump |> ignore    
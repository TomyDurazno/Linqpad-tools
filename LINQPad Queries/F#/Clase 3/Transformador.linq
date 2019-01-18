<Query Kind="FSharpProgram" />

// Despues convertir los numeros en texto. Ejemplos: 20 -> Veinte, 32 -> Treintaidos, 44 -> Cuarentaicuatro
let transformador start step num : string list =
    
    let algunValor algunInt =
        match algunInt with
            | 20 -> "Veinte"
            | 23 -> "Veintitres"
            | 26 -> "Veintiseis"
            | 29 -> "Veintinueve"
            | 30 -> "Treinta"
            | 32 -> "Treintaidos"
            | 40 -> "Cuarenta"
            | 42 -> "Cuarentaidos"
            | 44 -> "Cuarentaicuatro"
            | 46 -> "Cuarentaiseis"
            | 48 -> "Cuarentaiocho"
            | 50 -> "Cincuenta"
            | _ -> "xx"

    let result = Seq.initInfinite (fun x -> (start + x))
                    |> Seq.mapi (fun i n -> (i, n))
                    |> Seq.filter (fun t -> (fst t) % step = 0 )
                    |> Seq.skipWhile (fun t -> start > (snd t))
                    |> Seq.take num
                    |> Seq.map snd
                    |> Seq.map algunValor

    result |> List.ofSeq

    
transformador 20 10 6 |> Dump
module CryptoSquare

open System

let private dimensions length =
    let root = length |> float |> sqrt
    let lo, hi = (floor root |> int), (ceil root |> int)

    [ lo, lo; lo, hi; hi, hi ]
    |> List.skipWhile (fun (a, b) -> a * b < length)
    |> List.head

let private transpose text =
    let length = String.length text
    let rows, cols = dimensions length
    let padCount = (rows * cols) - length

    text + String.replicate padCount " "
    |> Seq.chunkBySize cols
    |> Seq.transpose
    |> Seq.map String.Concat
    |> String.concat " "

let ciphertext (input: string): string =
    let cleaned =
        input
        |> String.filter Char.IsLetterOrDigit
        |> String.map Char.ToLower

    match String.length cleaned with
    | 0 | 1 -> cleaned
    | _ -> cleaned |> transpose
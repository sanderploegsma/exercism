module AtbashCipher

open System

let private convert key c =
    let convertLetter l =
        let index = List.findIndex ((=) l) key
        let lookup = List.rev key
        lookup.[index]

    match Char.ToLower(c) with
    | d when Char.IsDigit(d) -> Some d
    | l when Char.IsLetter(l) -> Some (convertLetter l)
    | _ -> None

let encode (str: string) =
    let key = ['a' .. 'z']
    str
    |> Seq.choose (convert key)
    |> Seq.chunkBySize 5
    |> Seq.map (String.Concat)
    |> String.concat " "

let decode (str: string) =
    let key = ['a' .. 'z'] |> List.rev
    str
    |> Seq.choose (convert key)
    |> String.Concat
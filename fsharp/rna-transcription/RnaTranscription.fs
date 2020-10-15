module RnaTranscription

let complement (n: char) =
    match n with
    | 'G' -> Some 'C'
    | 'C' -> Some 'G'
    | 'T' -> Some 'A'
    | 'A' -> Some 'U'
    | _ -> None

let toRna (dna: string): string =
    dna
    |> Seq.choose complement
    |> Seq.toArray
    |> System.String
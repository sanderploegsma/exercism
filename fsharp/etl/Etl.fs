module Etl

let transform (scoresWithLetters: Map<int, char list>): Map<char, int> =
    let transpose (score, letters) =
        Seq.map (fun letter -> letter, score) letters

    let lowercase (letter, score) = System.Char.ToLower letter, score

    scoresWithLetters
    |> Map.toSeq
    |> Seq.collect transpose
    |> Seq.map lowercase
    |> Map.ofSeq
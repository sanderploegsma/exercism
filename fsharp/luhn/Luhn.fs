module Luhn

open System

let valid (number: string) =
    let double x =
        match x + x with
        | y when y > 9 -> y - 9
        | y -> y

    let validate n =
        let checksum =
            Seq.rev n
            |> Seq.map (Char.GetNumericValue >> int)
            |> Seq.mapi (fun i x -> if i % 2 = 1 then double x else x)
            |> Seq.sum

        checksum % 10 = 0

    match number.Replace(" ", "") with
    | n when String.length n < 2 -> false
    | n when not (Seq.forall Char.IsDigit n) -> false
    | n -> validate n

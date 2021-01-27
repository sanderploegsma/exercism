module IsbnVerifier

open System.Text.RegularExpressions

let parse (isbn: string) =
    match isbn.Replace("-", "") with
    | str when Regex.IsMatch(str, @"^\d{9}[\dX]$") -> Ok str
    | _ -> Error "invalid format"

let checksum isbn =
    let value c =
        match c with
        | 'X' -> 10
        | d -> System.Char.GetNumericValue(d) |> int

    isbn
    |> Seq.rev
    |> Seq.mapi (fun i c -> (value c) * (i + 1))
    |> Seq.sum
    |> fun x -> x % 11

let isValid isbn =
    match parse isbn with
    | Ok valid -> checksum valid = 0
    | Error _ -> false

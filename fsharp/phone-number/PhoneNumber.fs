module PhoneNumber

open System

let clean (input: string): Result<uint64, string> =

    let parse (str: string) =
        let isPunctuation (c: char) = Char.IsPunctuation(c) && not("().-+".Contains(c))

        match str with
        | s when Seq.exists Char.IsLetter s -> Error "letters not permitted"
        | s when Seq.exists isPunctuation s -> Error "punctuations not permitted"
        | s -> Ok (s |> String.filter Char.IsDigit)

    let validLength (digits: string) =
        match digits with
        | s when s.Length < 10 -> Error "incorrect number of digits"
        | s when s.Length > 11 -> Error "more than 11 digits"
        | s -> Ok s

    let validCountryCode (digits: string) =
        let (|WithCountryCode|WithoutCountryCode|) (s: string) =
            match s with
            | s when s.Length = 11 -> WithCountryCode (s.[0], s.[1..])
            | s -> WithoutCountryCode s

        match digits with
        | WithCountryCode (countryCode, _) when countryCode <> '1' -> Error "11 digits must start with 1"
        | WithCountryCode (_, number) -> Ok number
        | WithoutCountryCode number -> Ok number

    let validAreaCode (digits: string) =
        match digits.[0] with
        | '0' -> Error "area code cannot start with zero"
        | '1' -> Error "area code cannot start with one"
        | _ -> Ok digits

    let validExchangeCode (digits: string) =
        match digits.[3] with
        | '0' -> Error "exchange code cannot start with zero"
        | '1' -> Error "exchange code cannot start with one"
        | _ -> Ok digits

    parse input
    |> Result.bind validLength
    |> Result.bind validCountryCode
    |> Result.bind validAreaCode
    |> Result.bind validExchangeCode
    |> Result.map uint64

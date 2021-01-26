module Bob

let (|Question|_|) (s: string) =
    if s.EndsWith('?') then
        Some Question
    else
        None

let (|Yelling|_|) (s: string) =
    if s.ToUpperInvariant() = s
       && String.exists System.Char.IsLetter s then
        Some Yelling
    else
        None

let response (input: string): string =
    match input.Trim() with
    | Yelling & Question -> "Calm down, I know what I'm doing!"
    | Yelling -> "Whoa, chill out!"
    | Question -> "Sure."
    | "" -> "Fine. Be that way!"
    | _ -> "Whatever."

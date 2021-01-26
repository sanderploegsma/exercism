module CollatzConjecture

let (|Invalid|One|Even|Odd|) n =
    if n <= 0 then Invalid
    elif n = 1 then One
    elif n % 2 = 0 then Even
    else Odd

let inc n = n + 1

let rec steps (number: int): int option =
    match number with
    | Invalid -> None
    | One -> Some 0
    | Even -> steps (number / 2) |> Option.map inc
    | Odd -> steps (3 * number + 1) |> Option.map inc
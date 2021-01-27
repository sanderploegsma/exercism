module Triangle

let (|Triangle|_|) (sides: float list) =
    match sides with
    | [ a; b; c ] when a = 0.0 || b = 0.0 || c = 0.0 -> None
    | [ a; b; c ] when a + b >= c && a + c >= b && b + c >= a -> Some Triangle
    | _ -> None

let (|UniqueSides|_|) n sides =
    if List.distinct sides |> List.length = n then
        Some UniqueSides
    else
        None

let equilateral =
    function
    | Triangle & UniqueSides 1 -> true
    | _ -> false

let isosceles =
    function
    | Triangle & UniqueSides 1 -> true
    | Triangle & UniqueSides 2 -> true
    | _ -> false

let scalene =
    function
    | Triangle & UniqueSides 3 -> true
    | _ -> false

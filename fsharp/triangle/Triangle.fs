module Triangle

let (|Triangle|_|) (sides: float list) =
    match sides with
    | [ a; b; c ] when a + b >= c && a + c >= b && b + c >= a -> Some Triangle
    | _ -> None

let whenUniqueSides pred value sides =
    if List.distinct sides |> List.length |> pred then
        Some value
    else
        None

let (|Equilateral|_|) = whenUniqueSides ((=) 1) Equilateral
let (|Isosceles|_|) = whenUniqueSides ((>=) 2) Isosceles
let (|Scalene|_|) = whenUniqueSides ((=) 3) Scalene

let equilateral =
    function
    | Triangle & Equilateral -> true
    | _ -> false

let isosceles =
    function
    | Triangle & Isosceles -> true
    | _ -> false

let scalene =
    function
    | Triangle & Scalene -> true
    | _ -> false

module AllYourBase

let fromBase b digits = 
    digits
    |> List.rev
    |> List.mapi (fun i x -> x * (pown b i))
    |> List.sum

let toBase b value =
    let maxOrder = if value = 0 then 0 else (log (float value)) / (log (float b)) |> int

    let rec convert remainder i =
        let exp = pown b i
        let converted = remainder / exp
        if i = 0 then [converted] else [converted] @ (convert (remainder % exp) (i - 1))

    convert value maxOrder

let isInvalidInBase inputBase = 
    List.exists (fun x -> x < 0 || x >= inputBase)

let rec dropLeadingZeroes = function 
    | [0] -> [0]
    | head :: tail when head = 0 -> dropLeadingZeroes tail
    | x -> x

let rebase digits inputBase outputBase = 
    match (digits, inputBase, outputBase) with    
    | (_, x, y) when x <= 1 || y <= 1 -> None
    | (list, _, _) when list |> isInvalidInBase inputBase -> None
    | ([], _, _) -> Some [0]
    | (_, _, _) -> digits |> dropLeadingZeroes |> fromBase inputBase |> toBase outputBase |> Some
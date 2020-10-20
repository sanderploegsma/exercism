module SumOfMultiples

let isMultipleOf x y = y <> 0 && x % y = 0
let isMultipleOfAny list x = List.exists (isMultipleOf x) list

let sum (numbers: int list) (upperBound: int): int =
    seq { 1 .. upperBound - 1 }
    |> Seq.filter (isMultipleOfAny numbers)
    |> Seq.sum
module SumOfMultiples

let isMultipleOf x y = x % y = 0
let isMultipleOfAny list x = List.exists (isMultipleOf x) list

let sum (numbers: int list) (upperBound: int): int =
    seq { 1 .. upperBound }
    |> Seq.filter (isMultipleOfAny numbers)
    |> Seq.sum
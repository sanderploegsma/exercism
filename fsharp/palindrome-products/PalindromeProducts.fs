module PalindromeProducts

let private reverse =
    Array.ofSeq >> Array.rev >> System.String

let private isPalindrome n =
    let digits = sprintf "%d" n
    reverse digits = digits

let private products min max =
    if min > max then
        invalidArg "min" "invalid range"
    else
        [ for x in min .. max do
            for y in min .. max do
                if x <= y && isPalindrome (x * y) then yield x, y ]

let private palindromes min max =
    products min max
    |> List.groupBy (fun (x, y) -> x * y)
    |> List.sortBy fst

let largest min max =
    match List.tryLast (palindromes min max) with
    | Some (product, factors) -> Some product, factors
    | None -> None, []

let smallest min max =
    match List.tryHead (palindromes min max) with
    | Some (product, factors) -> Some product, factors
    | None -> None, []
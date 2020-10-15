module Grains

let square (n: int): Result<uint64,string> = 
    match n with
    | _ when n < 1 -> Error "square must be between 1 and 64"
    | n -> Ok (pown 2UL (n - 1))

let squareOrZero (n: int): uint64 =
    match square n with
    | Ok x -> x
    | Error _ -> 0UL

let total: Result<uint64,string> =
    seq { 1 .. 64 }
    |> Seq.sumBy squareOrZero
    |> Ok

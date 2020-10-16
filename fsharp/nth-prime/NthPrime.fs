module NthPrime

let isMultipleOf x y = x % y = 0

let prime nth : int option =
    if nth < 1 then
        None
    else
        let mutable primes = []
        let store prime =
            primes <- primes @ [prime]
            prime

        let isPrime x = primes |> List.exists (isMultipleOf x) |> not

        Seq.initInfinite id
        |> Seq.skip 2 // 0 and 1 are not considered primes
        |> Seq.filter isPrime
        |> Seq.map store
        |> Seq.skip (nth - 1)
        |> Seq.tryHead
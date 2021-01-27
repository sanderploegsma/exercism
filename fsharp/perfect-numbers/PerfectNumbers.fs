module PerfectNumbers

type Classification =
    | Perfect
    | Abundant
    | Deficient

let classify n =
    let factors x =
        [ for i in 1 .. x / 2 do
              if x % i = 0 then yield i ]

    let aliquotSum x = List.sum (factors x)

    let classification =
        function
        | sum when sum < n -> Deficient
        | sum when sum > n -> Abundant
        | _ -> Perfect

    Some n
    |> Option.filter (fun x -> x > 0)
    |> Option.map (aliquotSum >> classification)
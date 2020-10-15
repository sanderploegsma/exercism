module Darts

let score (x: double) (y: double): int =
    let dist = x * x + y * y |> sqrt
    match dist with
    | z when z <= 1.0 -> 10
    | z when z <= 5.0 -> 5
    | z when z <= 10.0 -> 1
    | _ -> 0
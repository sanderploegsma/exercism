module BinarySearch

let find input value =
    let rec search lst =
        let left, right =
            match List.length lst with
            | 0 -> [], []
            | 1 -> [], lst
            | n -> List.splitAt (n / 2 - 1) lst

        match left, right with
        | _, (i, x) :: _ when x = value -> Some i
        | l, (_, x) :: _ when x > value -> search l
        | _, (_, x) :: r when x < value -> search r
        | _ -> None

    input |> Array.toList |> List.indexed |> search
module LargestSeriesProduct

open System

let largestProduct (input: string) seriesLength : int option =
    let findLargestProduct digits length = 
        let charToInt = Seq.map (Char.GetNumericValue >> int)
        let product = Seq.fold (fun x y -> x * y) 1
        
        digits
        |> Seq.windowed length 
        |> Seq.map charToInt
        |> Seq.map product
        |> Seq.max

    let isValid = Seq.forall Char.IsDigit

    match (input.ToCharArray(), seriesLength) with
    | (_, y) when y < 0 -> None
    | (_, y) when y > input.Length -> None
    | (x, _) when not (isValid x) -> None
    | (_, y) when y = 0 -> Some 1
    | (x, _) when x.Length = 0 -> Some 1
    | (x, y) -> Some (findLargestProduct x y)
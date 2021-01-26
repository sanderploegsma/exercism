module ArmstrongNumbers

let isArmstrongNumber (number: int): bool =
    let digits =
        number
        |> string
        |> Seq.map (System.Char.GetNumericValue >> int)

    let digitsRaised =
        Seq.map (fun d -> pown d (Seq.length digits)) digits

    number = Seq.sum digitsRaised
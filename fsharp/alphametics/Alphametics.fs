module Alphametics

type Equation =
    { Terms: string list }

    member this.Left = this.Terms.[..this.Terms.Length - 2]

    member this.Right = List.last this.Terms

    member this.LeftLetters = this.Left |> Seq.collect id |> Set.ofSeq

    member this.RightLetters = this.Right |> Set.ofSeq

    member this.Letters =
        Set.union this.LeftLetters this.RightLetters

type Solution = Map<char, int>

let private parse (puzzle: string) =
    let terms =
        puzzle.Split(" == ")
        |> Seq.collect (fun s -> s.Split(" + "))
        |> Seq.toList

    { Terms = terms }

let private factors terms =
    let letterFactors term =
        Seq.rev term
        |> Seq.mapi (fun i c -> c, pown 10 i |> int64)

    terms
    |> Seq.collect letterFactors
    |> Seq.groupBy fst
    |> Seq.map (fun (c, f) -> c, Seq.sumBy snd f)

let rec private combinations n l =
    match n, l with
    | _, [] -> []
    | 1, xs -> List.map (fun x -> [ x ]) xs
    | k, xs ->
        combinations (k - 1) xs
        |> List.collect (fun c -> List.except c xs |> List.map (fun x -> c @ [ x ]))

let private solutions (equation: Equation): Solution seq =
    combinations (Set.count equation.Letters) [ 0 .. 9 ]
    |> Seq.map (Seq.zip equation.Letters >> Map.ofSeq)

let private findSolution equation =
    let nonZeroLetters =
        equation.Terms |> Seq.map (Seq.head) |> Set.ofSeq

    let noTermsStartWithZero (solution: Solution) =
        nonZeroLetters
        |> Seq.forall (fun c -> solution.[c] <> 0)

    let leftFactors, rightFactors =
        factors equation.Left, factors [ equation.Right ]

    let leftSumEqualsRightSum (solution: Solution) =
        let sum =
            Seq.sumBy (fun (c, f) -> (int64 solution.[c]) * f)

        sum leftFactors = sum rightFactors

    solutions equation
    |> Seq.filter noTermsStartWithZero
    |> Seq.filter leftSumEqualsRightSum
    |> Seq.tryHead

let private validate (equation: Equation) =
    match equation with
    | eq when Set.count eq.Letters > 10 -> Error "Too many letters in equation"
    | eq when (Seq.map String.length >> Seq.max) eq.Left > String.length eq.Right ->
        Error "Left side of equation has terms longer than the answer"
    | eq -> Ok eq

let solve puzzle =
    let equation = parse puzzle

    match validate equation with
    | Error _ -> None
    | Ok eq -> findSolution eq

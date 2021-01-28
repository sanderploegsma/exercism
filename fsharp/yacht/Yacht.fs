module Yacht

type Category =
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

type Die =
    | One = 1
    | Two = 2
    | Three = 3
    | Four = 4
    | Five = 5
    | Six = 6

let score category dice =
    let straight =
        [ Die.One
          Die.Two
          Die.Three
          Die.Four
          Die.Five
          Die.Six ]

    let isLittleStraight dice =
        List.sortBy int dice = List.take 5 straight

    let isBigStraight dice =
        List.sortBy int dice = List.skip 1 straight

    let isFullHouse dice =
        let counts = dice |> Seq.countBy id |> Seq.map snd
        Seq.length counts = 2 && Seq.exists ((=) 3) counts

    let isYacht dice = dice |> Seq.distinct |> Seq.length = 1

    let scoreNumbers dice die =
        (int die)
        * (dice |> Seq.filter ((=) die) |> Seq.length)

    let scoreFourOfAKind =
        Seq.countBy id
        >> Seq.filter (fun (_, count) -> count >= 4)
        >> Seq.map fst
        >> Seq.sumBy (fun die -> (int die) * 4)

    let sumOfDice = Seq.sumBy int

    match category with
    | Ones -> scoreNumbers dice Die.One
    | Twos -> scoreNumbers dice Die.Two
    | Threes -> scoreNumbers dice Die.Three
    | Fours -> scoreNumbers dice Die.Four
    | Fives -> scoreNumbers dice Die.Five
    | Sixes -> scoreNumbers dice Die.Six
    | Choice -> sumOfDice dice
    | FourOfAKind -> scoreFourOfAKind dice
    | FullHouse when isFullHouse dice -> sumOfDice dice
    | LittleStraight when isLittleStraight dice -> 30
    | BigStraight when isBigStraight dice -> 30
    | Yacht when isYacht dice -> 50
    | _ -> 0

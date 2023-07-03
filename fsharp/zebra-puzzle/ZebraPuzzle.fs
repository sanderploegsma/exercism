module ZebraPuzzle

open System

type Color =
    | Red
    | Green
    | Ivory
    | Yellow
    | Blue

type Resident =
    | Englishman
    | Spaniard
    | Ukranian
    | Norwegian
    | Japanese

type Pet =
    | Dog
    | Snails
    | Fox
    | Horse
    | Zebra

type Beverage =
    | Coffee
    | Tea
    | Milk
    | OrangeJuice
    | Water

type Smokes =
    | OldGold
    | Kools
    | Chesterfields
    | LuckyStrike
    | Parliaments

let rec permutations =
    function
    | [] -> seq [ List.empty ]
    | x :: xs -> Seq.collect (insertions x) (permutations xs)

and insertions x =
    function
    | [] -> [ [ x ] ]
    | (y :: ys) as xs -> (x :: xs) :: (List.map (fun x -> y :: x) (insertions x ys))

let private house item = List.findIndex ((=) item)

let private filterColors =
    permutations [ Red; Green; Ivory; Yellow; Blue ]
    |> Seq.filter (fun colors ->
        // The green house is immediately to the right of the ivory house.
        (house Green colors) + 1 = (house Ivory colors))

let private filterResidents colors =
    permutations [ Englishman; Spaniard; Ukranian; Norwegian; Japanese ]
    |> Seq.filter (fun residents ->
        // The Norwegian lives in the first house.
        (house Norwegian residents) = 0
        // The Norwegian lives next to the blue house.
        && Math.Abs((house Norwegian residents) - (house Blue colors)) = 1
        // The Englishman lives in the red house.
        && (house Englishman residents) = (house Red colors))

let private filterBeverages colors residents =
    permutations [ Coffee; Tea; Milk; OrangeJuice; Water ]
    |> Seq.filter (fun beverages ->
        // Coffee is drunk in the green house.
        (house Coffee beverages) = (house Green colors)
        // The Ukranian drinks tea.
        && (house Ukranian residents) = (house Tea beverages)
        // Milk is drunk in the middle house.
        && (house Milk beverages) = 2)

let private filterSmokes colors residents beverages =
    permutations [ OldGold; Kools; Chesterfields; LuckyStrike; Parliaments ]
    |> Seq.filter (fun smokes ->
        // Kools are smoked in the second house.
        (house Kools smokes) = (house Yellow colors)
        // The Lucky Strike smoker drinks orange juice.
        && (house LuckyStrike smokes) = (house OrangeJuice beverages)
        // The Japanese smokes Parliaments.
        && (house Japanese residents) = (house Parliaments smokes))

let private filterPets residents smokes =
    permutations [ Dog; Snails; Fox; Horse; Zebra ]
    |> Seq.filter (fun pets ->
        // The Spaniard owns the dog.
        (house Dog pets) = (house Spaniard residents)
        // The Old Gold smoker owns snails.
        && (house OldGold smokes) = (house Snails pets)
        // The man who smokes Chesterfields lives in the house next to the man with the fox.
        && Math.Abs((house Chesterfields smokes) - (house Fox pets)) = 1
        // Kools are smoked in the house next to the house where the horse is kept.
        && Math.Abs((house Kools smokes) - (house Horse pets)) = 1)

let private combinations =
    seq {
        for colors in filterColors do
            for residents in filterResidents colors do
                for beverages in filterBeverages colors residents do
                    for smokes in filterSmokes colors residents beverages do
                        for pets in filterPets residents smokes do
                            yield (colors, residents, beverages, smokes, pets)
    }

let (colors, residents, beverages, smokes, pets) = Seq.head combinations

let drinksWater = List.item (house Water beverages) residents

let ownsZebra = List.item (house Zebra pets) residents

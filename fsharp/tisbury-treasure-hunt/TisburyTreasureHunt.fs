module TisburyTreasureHunt

open System

type Coordinate = (int * char)
type AzarasData = (string * string)
type RuisData = (string * Coordinate * string)

let getCoordinate (line: AzarasData) : string = line |> snd

let convertCoordinate (coordinate: string) : int * char =
    coordinate.ToCharArray()
    |> Array.pairwise
    |> Array.head
    |> fun (a, b) -> (Int32.Parse(string a), b)

let compareRecords (azarasData: AzarasData) (ruisData: RuisData) : bool =
    let (_, c1) = azarasData
    let (_, c2, _) = ruisData
    (convertCoordinate c1) = c2

let createRecord (azarasData: AzarasData) (ruisData: RuisData) : (string * string * string * string) =
    let (treasure, coordinate) = azarasData
    let (location, _, quadrant) = ruisData

    if compareRecords azarasData ruisData then
        (coordinate, location, quadrant, treasure)
    else
        ("", "", "", "")

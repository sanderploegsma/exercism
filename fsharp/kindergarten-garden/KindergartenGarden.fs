module KindergartenGarden

type Plant =
    | Grass
    | Clover
    | Radishes
    | Violets

let students =
    [ "Alice"
      "Bob"
      "Charlie"
      "David"
      "Eve"
      "Fred"
      "Ginny"
      "Harriet"
      "Ileana"
      "Joseph"
      "Kincaid"
      "Larry" ]

let toPlant =
    function
    | 'G' -> Grass
    | 'C' -> Clover
    | 'R' -> Radishes
    | 'V' -> Violets
    | n -> failwithf "unknown plant '%c'" n

let plants (diagram: string) student =
    diagram.Split("\n")
    |> Array.toSeq
    |> Seq.map (Seq.chunkBySize 2)
    |> Seq.collect (Seq.zip students)
    |> Seq.filter (fun (s, _) -> s = student)
    |> Seq.collect snd
    |> Seq.map toPlant
    |> Seq.toList

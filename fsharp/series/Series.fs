module Series

let slices (str: string) length =
    let create l = 
        str
        |> Seq.windowed l
        |> Seq.map System.String.Concat
        |> Seq.toList

    Some length
    |> Option.filter (fun l -> l > 0)
    |> Option.filter (fun l -> l <= str.Length)
    |> Option.map create

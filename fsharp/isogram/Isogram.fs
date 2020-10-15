module Isogram

let isIsogram (str: string) = 
    str.ToLowerInvariant()
    |> Seq.filter "abcdefghijklmnopqrstuvwxyz".Contains
    |> Seq.countBy (fun c -> c) 
    |> Seq.forall (fun (c, x) -> x = 1)
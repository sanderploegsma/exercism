module Anagram

let findAnagrams (sources: string list) (target: string) =
    let chars str = Seq.sort str |> Seq.toArray

    let isAnagram (candidate: string) =
        let a, b = candidate.ToLower(), target.ToLower()
        a <> b && chars a = chars b

    List.filter isAnagram sources
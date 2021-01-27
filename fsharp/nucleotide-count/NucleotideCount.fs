module NucleotideCount

let nucleotideCounts (strand: string): Option<Map<char, int>> =
    let nucleotides = [ 'A'; 'C'; 'G'; 'T' ]

    let isNucleotide c = Seq.contains c nucleotides

    let countNucleotides str =
        let count n =
            str |> Seq.filter (fun c -> n = c) |> Seq.length

        nucleotides
        |> Seq.map (fun n -> n, count n)
        |> Map.ofSeq

    Some strand
    |> Option.filter (Seq.forall isNucleotide)
    |> Option.map countNucleotides

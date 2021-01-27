module ProteinTranslation

let translate =
    function
    | "AUG" -> Some "Methionine"
    | "UUU"
    | "UUC" -> Some "Phenylalanine"
    | "UUA"
    | "UUG" -> Some "Leucine"
    | "UCU"
    | "UCC"
    | "UCA"
    | "UCG" -> Some "Serine"
    | "UAU"
    | "UAC" -> Some "Tyrosine"
    | "UGU"
    | "UGC" -> Some "Cysteine"
    | "UGG" -> Some "Tryptophan"
    | "UAA"
    | "UAG"
    | "UGA" -> None
    | codon -> invalidArg codon "Unknown codon"

let proteins rna =
    Seq.chunkBySize 3 rna
    |> Seq.map System.String
    |> Seq.map translate
    |> Seq.takeWhile Option.isSome
    |> Seq.choose id
    |> Seq.toList
codons = {
    "AUG": "Methionine",
    "UUU": "Phenylalanine",
    "UUC": "Phenylalanine",
    "UUA": "Leucine",
    "UUG": "Leucine",
    "UCU": "Serine",
    "UCC": "Serine",
    "UCA": "Serine",
    "UCG": "Serine",
    "UAU": "Tyrosine",
    "UAC": "Tyrosine",
    "UGU": "Cysteine",
    "UGC": "Cysteine",
    "UGG": "Tryptophan",
}

stop = ["UAA", "UAG", "UGA"]


def proteins(strand):
    if len(strand) % 3 != 0:
        raise Error("Invalid RNA sequence")

    sequence = [strand[i : i + 3] for i in range(0, len(strand), 3)]

    result = []
    for codon in sequence:
        if codon in stop:
            break

        result.append(codons[codon])

    return result

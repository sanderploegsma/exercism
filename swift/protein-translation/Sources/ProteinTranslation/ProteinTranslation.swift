import Foundation

enum TranslationError: Error {
  case invalidCodon
}

enum Translation {
  case protein(String)
  case stop
}

func translationOfRNA(rna strand: String) throws -> [String] {
  var proteins = [String]()
  var i = strand.startIndex

  while let nextIndex = strand.index(i, offsetBy: 3, limitedBy: strand.endIndex) {
    let translation = try translate(codon: String(strand[i..<nextIndex]))
    switch translation {
    case .protein(let protein):
      proteins.append(protein)
    case .stop:
      return proteins
    }
    i = nextIndex
  }

  guard i == strand.endIndex else {
    throw TranslationError.invalidCodon
  }

  return proteins
}

private func translate(codon: String) throws -> Translation {
  switch codon {
  case "AUG":
    return .protein("Methionine")
  case "UUU", "UUC":
    return .protein("Phenylalanine")
  case "UUA", "UUG":
    return .protein("Leucine")
  case "UCU", "UCC", "UCA", "UCG":
    return .protein("Serine")
  case "UAU", "UAC":
    return .protein("Tyrosine")
  case "UGU", "UGC":
    return .protein("Cysteine")
  case "UGG":
    return .protein("Tryptophan")
  case "UAA", "UAG", "UGA":
    return .stop
  default:
    throw TranslationError.invalidCodon
  }
}

enum NucleotideCountErrors: Error {
  case invalidNucleotide
}

private let nucleotides = ["A", "C", "G", "T"]

class DNA {
  private let strand: String

  init(strand: String) throws {
    guard strand.allSatisfy({ nucleotides.contains(String($0)) }) else {
      throw NucleotideCountErrors.invalidNucleotide
    }

    self.strand = strand
  }

  func counts() -> [String: Int] {
    let initial = nucleotides.reduce(into: [String: Int]()) { $0[$1] = 0 }
    return self.strand.reduce(into: initial) { acc, cur in
      acc[String(cur), default: 0] += 1
    }
  }
}

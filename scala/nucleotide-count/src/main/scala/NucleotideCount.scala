class DNA(strand: String) {
  private val allowedNucleotides = Set('A', 'C', 'G', 'T')

  def nucleotideCounts: Either[Throwable, Map[Char, Int]] =
    validate.map { validStrand =>
      allowedNucleotides
        .map(c => (c, validStrand.count(_ == c)))
        .toMap
    }

  private def validate: Either[Throwable, String] = {
    if (!strand.forall(allowedNucleotides.contains)) {
      return Left(new IllegalArgumentException("Invalid input"))
    }

    Right(strand)
  }
}
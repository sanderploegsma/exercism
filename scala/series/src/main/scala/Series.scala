object Series {
  def slices(length: Int, seq: String): Seq[Seq[Int]] =
    seq.map(_.asDigit).sliding(length).toList
}
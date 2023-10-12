object RnaTranscription {
  def toRna(dna: String): Option[String] =
    dna.toCharArray.map(toRna).foldLeft(Option(""))((acc, cur) =>
      (acc, cur) match {
        case (None, _) | (_, None) => None
        case (Some(s), Some(c)) => Some(s + c)
      })

  private def toRna(dna: Char): Option[Char] = dna match {
    case 'G' => Some('C')
    case 'C' => Some('G')
    case 'T' => Some('A')
    case 'A' => Some('U')
    case _ => None
  }
}

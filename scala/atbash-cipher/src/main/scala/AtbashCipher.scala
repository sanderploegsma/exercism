object AtbashCipher {
  private val alphabet = 'a' to 'z'
  private val chunkSize = 5

  def encode(plainText: String): String =
    plainText
      .map(convert(_, alphabet))
      .collect { case Some(c) => c }
      .sliding(chunkSize, chunkSize)
      .map(_.mkString)
      .mkString(" ")

  def decode(cipherText: String): String =
    cipherText
      .replaceAll(" ", "")
      .map(convert(_, alphabet.reverse))
      .collect { case Some(c) => c }
      .mkString

  private def convert(char: Char, key: Seq[Char]) = char match {
    case c if c.isDigit => Some(c)
    case c if c.isLetter => Some(key.reverse(key.indexOf(c.toLower)))
    case _ => None
  }
}
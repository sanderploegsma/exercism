object Isogram {
  def isIsogram(input: String): Boolean = {
    val chars = input.filter(_.isLetter).map(_.toLower)
    chars.distinct == chars
  }
}

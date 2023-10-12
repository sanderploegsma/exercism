object Anagram {
  def findAnagrams(word: String, candidates: Seq[String]): Seq[String] = {
    candidates
      .filterNot(word.equalsIgnoreCase)
      .filter(_.toLowerCase.sorted == word.toLowerCase.sorted)
  }
}

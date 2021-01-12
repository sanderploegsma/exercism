case class PalindromeProducts(lower: Int, upper: Int) {
  private val factors =
    for {
      (x, i1) <- (lower to upper).zipWithIndex
      (y, i2) <- (lower to upper).zipWithIndex
      if i1 <= i2
    } yield (x, y)

  private val palindromes =
    factors
      .filter { case (x, y) => isPalindrome(x * y) }
      .groupBy { case (x, y) => x * y }
      .map { case (product, factors) => (product, factors.toSet) }
      .toSeq
      .sortBy(_._1)

  def smallest: Option[(Int, Set[(Int, Int)])] = palindromes.headOption

  def largest: Option[(Int, Set[(Int, Int)])] = palindromes.lastOption

  private def isPalindrome(i: Int): Boolean = {
    val digits = i.toString
    digits.reverse == digits
  }
}
object DifferenceOfSquares {
  def sumOfSquares(n: Int): Int = (1 to n).map(square).sum

  def squareOfSum(n: Int): Int = (square _).apply((1 to n).sum)

  def differenceOfSquares(n: Int): Int = squareOfSum(n) - sumOfSquares(n)

  private def square(n: Int) = n * n
}

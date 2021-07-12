object Grains {
  private val squares = 64

  def square(n: Int): Option[BigInt] = {
    if (n < 1 || n > squares)
      None
    else
      Some(BigInt.int2bigInt(1) << (n - 1))
  }

  def total: BigInt = (1 to squares).map(square(_).get).sum
}
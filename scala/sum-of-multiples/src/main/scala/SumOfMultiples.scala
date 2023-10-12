object SumOfMultiples {
  def sum(factors: Set[Int], limit: Int): Int =
    (1 until limit)
      .filter(i => factors.exists(i % _ == 0))
      .sum
}


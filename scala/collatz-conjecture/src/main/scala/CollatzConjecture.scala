object CollatzConjecture {
  def steps(n: Int): Option[Int] = n match {
    case x if x <= 0 => None
    case _ => Some(calculate(n))
  }

  private def calculate(n: Int): Int = n match {
    case 1 => 0
    case x if x % 2 == 0 => 1 + calculate(n / 2)
    case x if x % 2 == 1 => 1 + calculate(3 * n + 1)
  }
}
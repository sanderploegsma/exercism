object AllYourBase {
  def rebase(from: Int, digits: List[Int], to: Int): Option[List[Int]] = {
    if (from < 2 || to < 2) return None
    if (digits.exists(_ < 0)) return None
    if (digits.exists(_ >= from)) return None
    if (digits.isEmpty) return Some(List(0))

    val numerical = fromBase(from, digits)
    val result = toBase(to, numerical)

    Some(result)
  }

  private def fromBase(base: Int, digits: List[Int]): Int = digits.reverse.zipWithIndex.map {
    case (n, i) => n * Math.pow(base, i).toInt
  }.sum

  private def toBase(base: Int, value: Int): List[Int] = {
    val maxOrder = if (value == 0) 0 else (Math.log(value) / Math.log(base)).toInt

    def convert(remainder: Int, i: Int): List[Int] = {
      val exp = Math.pow(base, i).toInt
      val converted = remainder / exp

      i match {
        case 0 => List(converted)
        case _ => List(converted) ++ convert(remainder % exp, i - 1)
      }
    }

    convert(value, maxOrder)
  }
}
object Series {
  def largestProduct(length: Int, digits: String): Option[Int] = {
    if (length < 0 || length > digits.length)
      return None

    if (!digits.forall(_.isDigit))
      return None

    length match {
      case 0 => Some(1)
      case n => Some(digits.sliding(n, 1).map(_.map(_.asDigit).product).max)
    }
  }
}
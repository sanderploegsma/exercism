object Hamming {
  def distance(first: String, second: String): Option[Int] =
    Option.apply((first.toCharArray, second.toCharArray))
      .filter { case (a, b) => a.length == b.length }
      .map { case (a, b) => a.zip(b) }
      .map(_.count { case (a, b) => a != b })
}
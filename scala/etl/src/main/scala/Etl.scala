object Etl {
  def transform(scores: Map[Int, Seq[String]]): Map[String, Int] =
    scores
      .flatMap { case (score, letters) => letters.map((_, score)) }
      .mapKeys(_.toLowerCase)

  // mapKeys should just be in the standard library IMO
  implicit class MapFunctions[A, B](val map: Map[A, B]) extends AnyVal {
    def mapKeys[A1](f: A => A1): Map[A1, B] = map.map({ case (a, b) => (f(a), b) })
  }
}


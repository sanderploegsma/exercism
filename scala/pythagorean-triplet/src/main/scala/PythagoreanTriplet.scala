object PythagoreanTriplet {
  type Triplet = (Int, Int, Int)

  def isPythagorean(triplet: Triplet): Boolean = sorted(triplet) match {
    case (a, b, c) if a * a + b * b != c * c => false
    case (a, b, _) if a >= b => false
    case (_, b, c) if b >= c => false
    case _ => true
  }

  def pythagoreanTriplets(min: Int, max: Int): Seq[Triplet] = {
    for {
      a <- min to max
      b <- min to max
      c <- min to max
      if isPythagorean((a, b, c))
    } yield sorted((a, b, c))
  }.distinct

  private def sorted(triplet: Triplet): Triplet = {
    val a :: b :: c :: _ = List(triplet._1, triplet._2, triplet._3).sorted
    (a, b, c)
  }
}
object Darts {
  def score(x: Double, y: Double): Int = distanceToTarget(x, y) match {
    case n if n > 10 => 0
    case n if n > 5 => 1
    case n if n > 1 => 5
    case _ => 10
  }

  private def distanceToTarget(x: Double, y: Double) = math.hypot(x, y)
}

object HighScores {
  def latest(scores: Seq[Int]): Int = scores.last

  def personalBest(scores: Seq[Int]): Int = scores.max

  def personalTop(scores: Seq[Int]): Seq[Int] = scores.sorted(Ordering.Int.reverse).take(3)

  def report(scores: Seq[Int]): String = (latest(scores), personalBest(scores)) match {
    case (latest, best) if latest >= best => s"Your latest score was $latest. That's your personal best!"
    case (latest, best) => s"Your latest score was $latest. That's ${best - latest} short of your personal best!"
  }
}

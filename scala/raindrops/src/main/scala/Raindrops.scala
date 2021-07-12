object Raindrops {
  def convert(n: Int): String = {
    val sounds = Seq(3 -> "Pling", 5 -> "Plang", 7 -> "Plong")
      .filter(n % _._1 == 0)
      .map(_._2)

    Option(sounds)
      .filter(_.nonEmpty)
      .map(_.mkString)
      .getOrElse(n.toString)
  }
}


class School {
  type DB = Map[Int, Seq[String]]

  private var _db: DB = Map.empty

  def add(name: String, g: Int): Unit = {
    val names = grade(g) :+ name
    _db = _db + (g -> names)
  }

  def db: DB = _db

  def grade(g: Int): Seq[String] = _db.getOrElse(g, Seq())

  def sorted: DB = _db.mapValues(_.sorted).toSeq.sortBy(_._1).toMap
}


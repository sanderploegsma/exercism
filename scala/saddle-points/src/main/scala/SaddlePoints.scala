case class Matrix(values: Seq[Seq[Int]]) {
  private lazy val maxInRow = values.map(_.max)
  private lazy val minInCol = values.transpose.map(_.min)

  def saddlePoints: Set[(Int, Int)] = {
    for {
      row <- values.indices
      col <- values.head.indices
      if isSaddlePoint(row, col)
    } yield (row, col)
  }.toSet

  private def isSaddlePoint(row: Int, col: Int): Boolean = {
    val value = values(row)(col)
    value == maxInRow(row) && value == minInCol(col)
  }
}
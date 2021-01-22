case class Matrix(rows: Seq[Seq[Int]]) {

  case class MatrixValue(row: Int, col: Int, value: Int)

  val matrix: Seq[MatrixValue] =
    rows
      .zipWithIndex
      .flatMap { case (values, row) =>
        values
          .zipWithIndex
          .map { case (n, col) => MatrixValue(row, col, n) }
      }

  def saddlePoints: Set[(Int, Int)] = {
    val rowCandidates = select(_.row, row => row.maxBy(_.value))
    val colCandidates = select(_.col, col => col.minBy(_.value))

    rowCandidates.intersect(colCandidates).map(v => (v.row, v.col))
  }

  private def select(grouping: MatrixValue => Int, selector: Seq[MatrixValue] => MatrixValue) =
    matrix
      .groupBy(grouping)
      .values
      .flatMap { group =>
        val target = selector.apply(group)
        group.filter(_.value == target.value)
      }
      .toSet
}
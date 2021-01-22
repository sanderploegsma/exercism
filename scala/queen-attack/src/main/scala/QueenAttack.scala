case class Queen(row: Int, col: Int)

object Queen {
  def create(row: Int, col: Int): Option[Queen] = {
    if (isInRange(row) && isInRange(col))
      Some(Queen(row, col))
    else
      None
  }

  private def isInRange(n: Int) = 0 until 8 contains n
}

object QueenAttack {
  private val sameRow = (a: Queen, b: Queen) => a.row == b.row
  private val sameColumn = (a: Queen, b: Queen) => a.col == b.col
  private val sameDiagonal = (a: Queen, b: Queen) => Math.abs(a.row - b.row) == Math.abs(a.col - b.col)

  def canAttack(queen1: Queen, queen2: Queen): Boolean =
    Seq(sameRow, sameColumn, sameDiagonal).exists(_.apply(queen1, queen2))
}
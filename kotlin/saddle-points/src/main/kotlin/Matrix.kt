data class MatrixCoordinate(val row: Int, val col: Int)

class Matrix(private val values: List<List<Int>>) {
    val maxPerRow = values.map { it.maxOrNull() }
    val minPerCol = values.transpose().map { it.minOrNull() }

    val saddlePoints: Set<MatrixCoordinate> = sequence {
        for (row in values.indices) {
            for (col in values[row].indices) {
                if (isSaddlePoint(row, col)) {
                    yield(MatrixCoordinate(row + 1, col + 1))
                }
            }
        }
    }.toSet()

    private fun isSaddlePoint(row: Int, col: Int) = values[row][col].let {
        it == maxPerRow[row] && it == minPerCol[col]
    }

    private fun <T> List<List<T>>.transpose(): List<List<T>> {
        val rows = size
        val cols = firstOrNull()?.size ?: 0
        return List(cols) { j ->
            List(rows) { i ->
                this[i][j]
            }
        }
    }
}

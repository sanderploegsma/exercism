private const val MINE = '*'

data class MinesweeperBoard(private val board: List<String>) {
    init {
        require(board.map { it.length }.toSet().size <= 1) { "All rows should have equal length" }
    }

    fun withNumbers(): List<String> =
        board.mapIndexed { row, cells ->
            cells.mapIndexed { column, cell ->
                when (cell) {
                    MINE -> MINE
                    else -> getNumberValue(row, column)
                }
            }.joinToString("")
        }

    private fun getNumberValue(row: Int, column: Int): Char =
        when (val mineCount = neighboursOf(row, column).count { it == MINE }) {
            0 -> ' '
            else -> mineCount.digitToChar()
        }

    private fun neighboursOf(row: Int, column: Int): List<Char> =
        (row - 1..row + 1).flatMap { r ->
            (column - 1..column + 1).map { c ->
                Pair(r, c)
            }
        }
            .filterNot { (r, c) -> r == row && c == column }
            .filter { (r, c) -> r in board.indices && c in board[r].indices }
            .map { (r, c) -> board[r][c] }
}

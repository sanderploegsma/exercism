class Matrix(matrixAsString: String) {

    private val matrix = matrixAsString.lines().map {
        it.split(" ").map(String::toInt)
    }

    fun column(colNr: Int) = matrix.map { it[colNr - 1] }

    fun row(rowNr: Int) = matrix[rowNr - 1]
}

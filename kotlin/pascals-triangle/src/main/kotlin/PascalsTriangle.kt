object PascalsTriangle {

    fun computeTriangle(rows: Int): List<List<Int>> = (1..rows).map(::computeRow)

    private fun computeRow(row: Int): List<Int> = (0 until row).map { binomialCoefficient(row - 1, it) }

    private fun binomialCoefficient(n: Int, k: Int): Int {
        var n = n
        if (k > n) return 0
        var r = 1
        for (i in 1..k) {
            r *= n--
            r /= i
        }
        return r
    }
}

object SumOfMultiples {

    fun sum(factors: Set<Int>, limit: Int): Int =
        (1 until limit)
            .filter { factors.any { factor -> it.isMultipleOf(factor) } }
            .sum()

    private fun Int.isMultipleOf(x: Int) = when (x) {
        0 -> false
        else -> this % x == 0
    }
}

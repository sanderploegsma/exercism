object PrimeFactorCalculator {

    fun primeFactors(int: Int): List<Int> =
        generatePrimeFactors(int.toLong())
            .map { it.toInt() }
            .toList()

    fun primeFactors(long: Long): List<Long> =
        generatePrimeFactors(long)
            .toList()

    private fun generatePrimeFactors(n: Long) = sequence {
        var divisor = 2L
        var left = n

        while (left > 1) {
            if (left % divisor == 0L) {
                left /= divisor
                yield(divisor)
            } else {
                divisor++
            }
        }
    }
}

class Squares(n: Int) {
    private val numbers = 1..n

    fun sumOfSquares() = numbers.sumOf { it * it }

    fun squareOfSum() = numbers.sum().let { it * it }

    fun difference() = squareOfSum() - sumOfSquares()
}

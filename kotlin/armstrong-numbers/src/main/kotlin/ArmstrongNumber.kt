import kotlin.math.pow

object ArmstrongNumber {
    fun check(input: Int): Boolean {
        val digits = input.digits
        val sum = digits.sumOf { it.toDouble().pow(digits.size).toInt() }
        return input == sum
    }

    private val Int.digits get() = this.toString().map { it.digitToInt() }
}

import kotlin.math.floor
import kotlin.math.log10
import kotlin.math.pow

class BaseConverter(private val base: Int, private val digits: IntArray) {

    init {
        require(base >= 2) { "Bases must be at least 2." }
        require(digits.isNotEmpty()) { "You must supply at least one digit." }
        require(digits.first() != 0 || digits.size == 1) { "Digits may not contain leading zeros." }
        require(digits.all { it >= 0 }) { "Digits may not be negative." }
        require(digits.all { it < base }) { "All digits must be strictly less than the base." }
    }

    fun convertToBase(newBase: Int): IntArray {
        require(newBase >= 2) { "Bases must be at least 2." }

        return digits.value(base).digits(newBase)
    }

    private fun IntArray.value(base: Int): Int = toList()
            .reversed()
            .foldIndexed(0) { i, sum, d -> sum + d * base.toDouble().pow(i).toInt() }

    private fun Int.digits(base: Int): IntArray = sequence {
        val n = when (val x = this@digits) {
            0 -> 0
            else -> floor(log10(x.toDouble()) / log10(base.toDouble())).toInt()
        }

        var remainder = this@digits

        for (i in n downTo 0) {
            val exponent = base.toDouble().pow(i).toInt()
            yield((remainder / exponent))
            remainder %= exponent
        }
    }.toList().toIntArray()
}

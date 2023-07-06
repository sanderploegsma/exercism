
import java.math.BigInteger

object Board {

    private const val size = 64

    fun getGrainCountForSquare(number: Int): BigInteger = when {
        number < 1 -> throw IllegalArgumentException()
        number > size -> throw IllegalArgumentException()
        else -> 2.0.toBigDecimal().pow(number - 1).toBigInteger()
    }

    fun getTotalGrainCount(): BigInteger = (1..size).sumOf(::getGrainCountForSquare)
}

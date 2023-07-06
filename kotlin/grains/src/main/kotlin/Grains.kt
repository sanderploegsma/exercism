
import java.math.BigInteger

object Board {

    private const val size = 64

    fun getGrainCountForSquare(number: Int): BigInteger {
        require(number in 1..size)
        return BigInteger.valueOf(2).pow(number - 1)
    }

    fun getTotalGrainCount(): BigInteger = BigInteger.valueOf(2).pow(size) - BigInteger.ONE
}

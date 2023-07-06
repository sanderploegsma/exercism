import java.math.BigInteger
import java.util.*

object DiffieHellman {

    private val randomSource = Random()

    fun privateKey(prime: BigInteger): BigInteger =
        generateSequence { BigInteger(prime.bitLength(), randomSource) }
            .first { it >= BigInteger.ONE && it < prime }

    fun publicKey(p: BigInteger, g: BigInteger, privateKey: BigInteger): BigInteger = g.modPow(privateKey, p)

    fun secret(prime: BigInteger, publicKey: BigInteger, privateKey: BigInteger): BigInteger =
        publicKey.modPow(privateKey, prime)
}

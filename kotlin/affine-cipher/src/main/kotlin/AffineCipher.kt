import java.math.BigInteger

object AffineCipher {
    private val alphabet = ('a'..'z').toList()
    private val m = alphabet.size

    fun encode(input: String, a: Int, b: Int): String {
        require(a.isCoprimeWith(m))

        return input
                .transform { a * it + b }
                .chunked(5)
                .joinToString(separator = " ")
    }

    fun decode(input: String, a: Int, b: Int): String {
        require(a.isCoprimeWith(m))

        val aInverse = a.modInverse(m)
        return input.transform { aInverse * (it - b) }
    }

    private fun String.transform(f: (Int) -> Int): String =
            lowercase()
                    .filter { it.isLetterOrDigit() }
                    .map { c ->
                        when (val i = alphabet.indexOf(c)) {
                            -1 -> c
                            else -> alphabet[f(i).mod(m)]
                        }
                    }
                    .joinToString(separator = "")

    private fun gcd(a: Int, b: Int): Int = if (b == 0) a else gcd(b, a % b)
    private fun Int.isCoprimeWith(x: Int) = gcd(this, x) == 1
    private fun Int.modInverse(m: Int): Int =
            BigInteger.valueOf(this.toLong())
                    .modInverse(BigInteger.valueOf(m.toLong()))
                    .toInt()
}

import kotlin.math.ceil
import kotlin.math.sqrt

object CryptoSquare {

    fun ciphertext(input: String): String {
        val plaintext = input.lowercase().filter { it.isLetterOrDigit() }.also {
            if (it.isBlank()) {
                return ""
            }
        }

        val columns = ceil(sqrt(plaintext.length.toDouble())).toInt()

        val rectangle = plaintext
            .chunked(columns)
            .map { it.padEnd(columns, ' ') }

        return (0 until columns).joinToString(" ") { col ->
            rectangle.map { it[col] }.joinToString("")
        }
    }

}

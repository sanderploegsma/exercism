private const val CHECK_DIGIT = 'X'

class IsbnVerifier {

    fun isValid(number: String): Boolean {
        val digits = number.filter { it.isLetterOrDigit() }

        if (digits.length != 10) {
            return false
        }

        var checksum = 0

        for ((index, digit) in digits.reversed().withIndex()) {
            checksum += when {
                digit == CHECK_DIGIT && index == 0 -> 10
                digit.isDigit() -> digit.digitToInt() * (index + 1)
                else -> return false
            }
        }

        return checksum % 11 == 0
    }
}

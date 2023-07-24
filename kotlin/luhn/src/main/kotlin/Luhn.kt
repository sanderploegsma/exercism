object Luhn {

    fun isValid(candidate: String): Boolean {
        val digits = candidate.filter { it != ' ' }.also { s ->
            if (s.length <= 1 || !s.all { it.isDigit() }) {
                return false
            }
        }

        val checksum = digits
            .reversed()
            .mapIndexed { i, c ->
                val d = c.digitToInt()
                if (i % 2 == 1) d.double() else d
            }.sum()

        return checksum % 10 == 0
    }

    private fun Int.double() = when (val double = this * 2) {
        in 0..9 -> double
        else -> double - 9
    }
}

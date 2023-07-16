object RunLengthEncoding {

    fun encode(input: String): String = buildString {
        var remaining = input
        while (remaining.isNotEmpty()) {
            val batch = remaining.takeWhile { it == remaining.first() }

            if (batch.length > 1) {
                append(batch.length)
            }

            append(batch.first())
            remaining = remaining.drop(batch.length)
        }
    }

    fun decode(input: String): String = buildString {
        var remaining = input
        while (remaining.isNotEmpty()) {
            val digits = remaining.takeWhile { it.isDigit() }
            val char = remaining.drop(digits.length).first()
            val count = when (digits) {
                "" -> 1
                else -> digits.toInt()
            }
            append("$char".repeat(count))
            remaining = remaining.drop(digits.length + 1)
        }
    }
}

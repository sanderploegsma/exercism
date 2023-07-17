object Atbash {
    private val plain = ('a'..'z').joinToString("")
    private val cipher = plain.reversed()

    fun encode(s: String) = s.transform(from = plain, to = cipher).chunked(5).joinToString(" ")

    fun decode(s: String) = s.transform(from = cipher, to = plain)

    private fun String.transform(from: String, to: String) =
        lowercase()
            .filter { it.isLetterOrDigit() }
            .map { c ->
                when (val i = from.indexOf(c)) {
                    -1 -> c
                    else -> to[i]
                }
            }
            .joinToString("")
}

class RotationalCipher(private val key: Int) {
    private val cipher = createCipher('a'..'z', 'A'..'Z')

    fun encode(text: String): String =
        text.map { cipher.getOrDefault(it, it) }.joinToString("")

    private fun createCipher(vararg ranges: CharRange) = buildMap {
        for (range in ranges) {
            val items = range.toList()
            putAll(items.associateWith { range.first + (it - range.first + key) % items.size })
        }
    }
}

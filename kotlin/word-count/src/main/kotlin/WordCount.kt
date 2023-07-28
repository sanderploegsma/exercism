object WordCount {
    private val separators = Regex("""[\s,;]+""")

    fun phrase(phrase: String): Map<String, Int> {
        val words = phrase
            .lowercase()
            .split(separators)
            .map { word -> word.trim { !it.isLetterOrDigit() } }
            .filter { it.isNotBlank() }

        return words.groupingBy { it }.eachCount()
    }
}

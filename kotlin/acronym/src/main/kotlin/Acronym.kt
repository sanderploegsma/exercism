object Acronym {
    private val delimiters = charArrayOf(' ', '-', ',', '_', '*')

    fun generate(phrase: String) = phrase
        .split(*delimiters)
        .mapNotNull { it.firstOrNull()?.uppercase() }
        .joinToString("")
}

object Raindrops {

    private val factors = mapOf(
        3 to "Pling",
        5 to "Plang",
        7 to "Plong",
    )

    fun convert(n: Int) = buildString {
        factors.filterKeys { n % it == 0 }.values.forEach(this::append)

        if (isBlank()) {
            append(n)
        }
    }
}

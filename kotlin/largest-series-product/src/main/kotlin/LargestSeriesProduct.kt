class Series(private val digits: String) {

    init {
        require(digits.all { it.isDigit() })
    }

    fun getLargestProduct(span: Int): Long {
        require(span > 0 && span <= digits.length)

        return digits
                .windowed(span, 1)
                .maxOf { it.fold(1L) { acc, d -> acc * (d - '0') } }
    }
}

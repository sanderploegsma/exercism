data class Year(val value: Int) {
    val isLeap: Boolean = when {
        value isDivisibleBy 400 -> true
        value isDivisibleBy 100 -> false
        value isDivisibleBy 4 -> true
        else -> false
    }

    private infix fun Int.isDivisibleBy(other: Int) = this % other == 0
}

class DiamondPrinter {
    fun printToList(letter: Char): List<String> {
        require(letter in 'A'..'Z') { "Not a valid letter: $letter" }

        val topLeft = ('A'..letter).map {
            "${space(letter - it)}$it${space(it - 'A')}"
        }

        val top = topLeft.map { it + it.reversed().drop(1) }
        return top + top.reversed().drop(1)
    }

    private fun space(width: Int) = " ".repeat(width)
}

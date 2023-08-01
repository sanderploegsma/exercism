object BeerSong {
    fun verses(startBottles: Int, takeDown: Int) =
        (startBottles downTo takeDown).joinToString("\n", transform = ::verse)

    private fun verse(bottles: Int): String {
        val howManyBottles = howManyBottles(bottles)
        val howManyBottlesLeft = howManyBottles(takeOneDown(bottles))
        val whatToDo = whatToDo(bottles)

        return "${howManyBottles.replaceFirstChar { it.uppercaseChar() }} of beer on the wall, $howManyBottles of beer.\n" +
                "${whatToDo.replaceFirstChar { it.uppercaseChar() }}, $howManyBottlesLeft of beer on the wall.\n"
    }

    private fun takeOneDown(bottles: Int) = when (bottles) {
        0 -> 99
        else -> bottles - 1
    }

    private fun howManyBottles(bottles: Int) = when (bottles) {
        0 -> "no more bottles"
        1 -> "1 bottle"
        else -> "$bottles bottles"
    }

    private fun whatToDo(bottles: Int) = when (bottles) {
        0 -> "go to the store and buy some more"
        else -> "take ${if (bottles == 1) "it" else "one"} down and pass it around"
    }
}

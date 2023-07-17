import YachtCategory.*

object Yacht {

    fun solve(category: YachtCategory, vararg dices: Int) = when (category) {
        ONES, TWOS, THREES, FOURS, FIVES, SIXES -> dices.filter { it == category.ordinal }.sum()
        YACHT -> scoreWhen(dices.isYacht, 50)
        FULL_HOUSE -> scoreWhen(dices.isFullHouse, dices.sum())
        FOUR_OF_A_KIND -> dices.scoreFourOfAKind()
        LITTLE_STRAIGHT -> scoreWhen(dices.isLittleStraight, 30)
        BIG_STRAIGHT -> scoreWhen(dices.isBigStraight, 30)
        CHOICE -> dices.sum()
    }

    private fun scoreWhen(condition: Boolean, score: Int) = if (condition) score else 0

    private val IntArray.isYacht get() = all { it == first() }

    private val IntArray.isFullHouse get() = groupBy { it }.values.map { it.size }.toSet() == setOf(2, 3)

    private val IntArray.isLittleStraight get() = sorted() == (1..5).toList()

    private val IntArray.isBigStraight get() = sorted() == (2..6).toList()

    private fun IntArray.scoreFourOfAKind() =
        groupBy { it }
            .values
            .firstOrNull { it.size >= 4 }
            ?.take(4)
            ?.sum()
            ?: 0
}

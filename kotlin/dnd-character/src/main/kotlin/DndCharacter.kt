import kotlin.math.floor
import kotlin.random.Random
import kotlin.random.nextInt

class DndCharacter {
    val strength: Int = ability()
    val dexterity: Int = ability()
    val constitution: Int = ability()
    val intelligence: Int = ability()
    val wisdom: Int = ability()
    val charisma: Int = ability()
    val hitpoints: Int = 10 + modifier(constitution)

    companion object {

        fun ability(): Int =
            generateSequence { Random.nextInt(1..6) }
                .take(4)
                .sortedDescending()
                .take(3)
                .sum()

        fun modifier(score: Int) = floor((score - 10) / 2.0).toInt()
    }

}

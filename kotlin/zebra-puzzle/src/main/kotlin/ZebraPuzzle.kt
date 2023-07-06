import kotlin.math.abs

enum class Color { Red, Green, Ivory, Yellow, Blue }
enum class Resident { Englishman, Spaniard, Ukranian, Norwegian, Japanese }
enum class Pet { Dog, Snails, Fox, Horse, Zebra }
enum class Drink { Coffee, Tea, Milk, OrangeJuice, Water }
enum class Smoke { OldGold, Kools, Chesterfields, LuckyStrike, Parliaments }

class ZebraPuzzle {

    private lateinit var colors: List<Color>
    private lateinit var residents: List<Resident>
    private lateinit var pets: List<Pet>
    private lateinit var drinks: List<Drink>
    private lateinit var smokes: List<Smoke>

    init {
        for (colors in permutations<Color>().filter { it.filterColors() }) {
            for (residents in permutations<Resident>().filter { it.filterResidents(colors) }) {
                for (drinks in permutations<Drink>().filter { it.filterDrinks(colors, residents) }) {
                    for (smokes in permutations<Smoke>().filter { it.filterSmokes(colors, residents, drinks) }) {
                        for (pets in permutations<Pet>().filter { it.filterPets(residents, smokes) }) {
                            this.colors = colors
                            this.residents = residents
                            this.pets = pets
                            this.drinks = drinks
                            this.smokes = smokes
                        }
                    }
                }
            }
        }
    }

    fun drinksWater(): String = residents[drinks.indexOf(Drink.Water)].name

    fun ownsZebra(): String = residents[pets.indexOf(Pet.Zebra)].name

    private fun List<Color>.filterColors(): Boolean =
        // The green house is immediately to the right of the ivory house.
        indexOf(Color.Green) + 1 == indexOf(Color.Ivory)

    private fun List<Resident>.filterResidents(colors: List<Color>): Boolean =
        // The Norwegian lives in the first house.
        indexOf(Resident.Norwegian) == 0 &&
                // The Norwegian lives next to the blue house.
                abs(indexOf(Resident.Norwegian) - colors.indexOf(Color.Blue)) == 1 &&
                // The Englishman lives in the red house.
                indexOf(Resident.Englishman) == colors.indexOf(Color.Red)

    private fun List<Drink>.filterDrinks(colors: List<Color>, residents: List<Resident>): Boolean =
        // Coffee is drunk in the green house.
        indexOf(Drink.Coffee) == colors.indexOf(Color.Green) &&
                // The Ukranian drinks tea.
                residents.indexOf(Resident.Ukranian) == indexOf(Drink.Tea) &&
                // Milk is drunk in the middle house.
                indexOf(Drink.Milk) == 2

    private fun List<Smoke>.filterSmokes(colors: List<Color>, residents: List<Resident>, drinks: List<Drink>): Boolean =
        // Kools are smoked in the yellow house.
        indexOf(Smoke.Kools) == colors.indexOf(Color.Yellow) &&
                // The Lucky Strike smoker drinks orange juice.
                indexOf(Smoke.LuckyStrike) == drinks.indexOf(Drink.OrangeJuice) &&
                // The Japanese smokes Parliaments.
                residents.indexOf(Resident.Japanese) == indexOf(Smoke.Parliaments)

    private fun List<Pet>.filterPets(residents: List<Resident>, smokes: List<Smoke>): Boolean =
        // The Spaniard owns the dog.
        residents.indexOf(Resident.Spaniard) == indexOf(Pet.Dog) &&
                // The Old Gold smoker owns snails.
                smokes.indexOf(Smoke.OldGold) == indexOf(Pet.Snails) &&
                // The man who smokes Chesterfields lives in the house next to the man with the fox.
                abs(smokes.indexOf(Smoke.Chesterfields) - indexOf(Pet.Fox)) == 1 &&
                // Kools are smoked in the house next to the house where the horse is kept.
                abs(smokes.indexOf(Smoke.Kools) - indexOf(Pet.Horse)) == 1
}

private inline fun <reified T : Enum<T>> permutations() = enumValues<T>().toList().permutations()

private fun <T> List<T>.permutations(): Sequence<List<T>> =
    if (size <= 1) sequenceOf(this)
    else asSequence().flatMap { seq -> (this - seq).permutations().map { listOf(seq) + it } }

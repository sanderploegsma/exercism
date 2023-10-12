private val children = listOf(
    "Alice",
    "Bob",
    "Charlie",
    "David",
    "Eve",
    "Fred",
    "Ginny",
    "Harriet",
    "Ileana",
    "Joseph",
    "Kincaid",
    "Larry",
)

class KindergartenGarden(diagram: String) {

    private val rows = diagram.split("\n").map { it.toCharArray() }

    fun getPlantsOfStudent(student: String): List<String> {
        val index = children.indexOf(student) * 2
        return rows.flatMap { listOf(it[index], it[index + 1]) }.map(::getPlantName)
    }

    private fun getPlantName(identifier: Char) = when (identifier) {
        'C' -> "clover"
        'G' -> "grass"
        'R' -> "radishes"
        'V' -> "violets"
        else -> throw IllegalArgumentException("No plant known with identifier $identifier")
    }
}

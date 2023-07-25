object Isogram {

    fun isIsogram(input: String) = input
        .lowercase()
        .toCharArray()
        .filter { it.isLetter() }
        .sorted()
        .zipWithNext()
        .all { (a, b) -> a != b }
}

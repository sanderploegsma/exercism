object Transpose {

    fun transpose(input: List<String>): List<String> {
        val transposedListLength = input.maxOfOrNull { it.length } ?: return emptyList()

        return List(transposedListLength) { i ->
            buildString {
                for ((index, string) in input.withIndex()) {
                    when {
                        string.length > i -> append(string[i])
                        input.drop(index + 1).any { it.length > i } -> append(" ")
                    }
                }
            }
        }
    }
}

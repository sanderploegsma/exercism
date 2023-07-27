/**
 * Reverses a string, assuming we shouldn't use input.reversed()
 */
fun reverse(input: String) = buildString {
    for (i in (input.length - 1 downTo 0)) {
        append(input[i])
    }
}

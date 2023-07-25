object MatchingBrackets {

    private val brackets = mapOf(
        '{' to '}',
        '(' to ')',
        '[' to ']',
    )

    fun isValid(input: String) = isValid(emptyList(), input)

    private tailrec fun isValid(stack: List<Char>, input: String): Boolean {
        if (input.isBlank()) {
            return stack.isEmpty()
        }

        val head = input.first()
        val tail = input.drop(1)
        val expected = stack.firstOrNull()?.let { brackets[it] }

        return when (head) {
            in brackets.keys -> isValid(listOf(head) + stack, tail)
            in brackets.values -> if (head == expected) isValid(stack.drop(1), tail) else false
            else -> isValid(stack, tail)
        }
    }
}

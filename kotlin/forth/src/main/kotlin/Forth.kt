import java.util.*

class Forth {
    fun evaluate(vararg lines: String): List<Int> {
        val sanitized = lines.map { it.lowercase() }.toList()
        val words = parseCustomWords(sanitized)
        val stack = Stack<Int>()

        for (term in sanitized.last().split(' ')) {
            stack.evaluate(term, words)
        }

        return stack.toList()
    }

    private fun Stack<Int>.evaluate(term: String, words: Map<String, List<String>>) {
        when {
            term.isNumber() -> push(term.toInt())
            term in words -> words[term]!!.forEach { evaluate(it, words) }
            term == "dup" -> operation { x -> listOf(x, x) }
            term == "drop" -> operation { _ -> emptyList() }
            term == "swap" -> operation { a, b -> listOf(b, a) }
            term == "over" -> operation { a, b -> listOf(a, b, a) }
            term == "+" -> operation { a, b -> listOf(a + b) }
            term == "-" -> operation { a, b -> listOf(a - b) }
            term == "*" -> operation { a, b -> listOf(a * b) }
            term == "/" -> operation { a, b ->
                require(b > 0) { "divide by zero" }
                listOf(a / b)
            }

            else -> throw UnsupportedOperationException("undefined operation")
        }
    }

    private fun Stack<Int>.operation(f: (Int) -> List<Int>) {
        require(isNotEmpty()) { "empty stack" }
        f.invoke(pop()).forEach(::push)
    }

    private fun Stack<Int>.operation(f: (Int, Int) -> List<Int>) {
        require(isNotEmpty()) { "empty stack" }
        require(size > 1) { "only one value on the stack" }
        val b = pop()
        val a = pop()
        f.invoke(a, b).forEach(::push)
    }

    private fun parseCustomWords(lines: List<String>): Map<String, List<String>> = buildMap {
        val pattern = Regex("""^: (.*) ;$""")

        for (line in lines.mapNotNull { pattern.find(it)?.groupValues?.last() }) {
            val (word, terms) = line.split(' ', limit = 2)
            require(!word.isNumber()) { "illegal operation" }
            put(word, terms.split(' ').flatMap { get(it) ?: listOf(it) })
        }
    }

    private fun String.isNumber() = all { it.isDigit() }
}

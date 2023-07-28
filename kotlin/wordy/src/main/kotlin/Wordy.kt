import kotlin.math.pow

object Wordy {
    private val mathQuestion = Regex("""^What is (.*)\?$""")

    fun answer(input: String): Int {
        val question = mathQuestion.find(input) ?: throw UnsupportedOperationException("Not a math question: $input")

        val expression = question.groupValues.last()
            .replace("plus", "+")
            .replace("minus", "-")
            .replace("multiplied by", "*")
            .replace("divided by", "/")
            .replace(Regex("""([-\d]+) raised to the (\d+)[a-z]+ power"""), "$1 ^ $2")
            .split(" ")

        return solve(expression)
    }

    private fun solve(expression: List<String>): Int {
        if (expression.size == 1) {
            return expression[0].toInt()
        }

        require(expression.size >= 3) { "Invalid expression: $expression" }

        return expression
            .drop(1)
            .chunked(2) { Pair(it[0], it[1].toInt())}
            .fold(expression[0].toInt()) { lhs, (op, rhs) ->
                when (op) {
                    "+" -> lhs + rhs
                    "-" -> lhs - rhs
                    "*" -> lhs * rhs
                    "/" -> lhs / rhs
                    "^" -> lhs.toDouble().pow(rhs).toInt()
                    else -> throw UnsupportedOperationException("Unknown operator: $op")
                }
            }
    }
}

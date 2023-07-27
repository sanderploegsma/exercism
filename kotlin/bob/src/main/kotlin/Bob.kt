object Bob {
    fun hey(input: String) = when {
        input.isQuestion && input.isYelled -> "Calm down, I know what I'm doing!"
        input.isQuestion -> "Sure."
        input.isYelled -> "Whoa, chill out!"
        input.isSilence -> "Fine. Be that way!"
        else -> "Whatever."
    }

    private val String.isQuestion get() = trim().endsWith("?")
    private val String.isYelled get() = any { it.isLetter() } && uppercase() == this
    private val String.isSilence get() = isBlank()
}

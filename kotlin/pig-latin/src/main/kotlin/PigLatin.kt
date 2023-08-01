object PigLatin {

    private val vowels = listOf("a", "e", "i", "o", "u", "yt", "xr")
    private val singleConsonants = ('a'..'z').map { "$it" }.filter { it !in vowels }
    private val consonants =
        listOf("ch", "qu", "thr", "th", "sch", "rh") + singleConsonants.map { it + "qu" } + singleConsonants

    fun translate(phrase: String) = phrase.split(' ').joinToString(" ", transform = ::translateWord)

    private fun translateWord(word: String): String {
        for (vowel in vowels) {
            if (word.startsWith(vowel)) {
                return word + "ay"
            }
        }

        for (consonant in consonants) {
            if (word.startsWith(consonant)) {
                return word.drop(consonant.length) + consonant + "ay"
            }
        }

        throw UnsupportedOperationException()
    }
}

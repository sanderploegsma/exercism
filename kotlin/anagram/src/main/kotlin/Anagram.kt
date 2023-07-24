class Anagram(word: String) {
    private val word = word.word()
    private val letters = word.letters()

    fun match(anagrams: Collection<String>) =
        anagrams
            .filterNot { it.word() == word }
            .filter { it.letters() == letters }
            .toSet()

    private fun String.word() = lowercase()
    private fun String.letters() = word().toCharArray().sorted()
}

private val keyRange = ('a'..'z').toList()
private fun randomKey() = List(100) { _ -> keyRange.random() }.joinToString("")

private enum class CipherMode {
    Encode, Decode
}

data class Cipher(val key: String) {

    init {
        require(key.isNotBlank())
        require(key.all { it in keyRange })
    }

    constructor() : this(randomKey())

    fun encode(s: String) = substitute(s, CipherMode.Encode)

    fun decode(s: String) = substitute(s, CipherMode.Decode)

    private fun substitute(s: String, mode: CipherMode) =
        s.mapIndexed { i, c -> substituteChar(c, i, mode) }.joinToString("")

    private fun substituteChar(char: Char, position: Int, mode: CipherMode): Char {
        val direction = when (mode) {
            CipherMode.Encode -> 1
            CipherMode.Decode -> -1
        }

        val offset = keyRange.indexOf(key[position % key.length]) * direction
        val index = (keyRange.indexOf(char) + offset).mod(keyRange.size)
        return keyRange[index]
    }
}

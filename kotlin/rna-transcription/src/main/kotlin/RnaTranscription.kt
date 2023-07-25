fun transcribeToRna(dna: String) = dna.map(::transcribe).joinToString("")

private fun transcribe(c: Char) = when (c) {
    'G' -> 'C'
    'C' -> 'G'
    'T' -> 'A'
    'A' -> 'U'
    else -> throw IllegalArgumentException()
}

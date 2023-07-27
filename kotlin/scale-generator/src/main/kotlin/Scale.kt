class Scale(private val tonic: String) {
    companion object {
        private val SHARPS = listOf("A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#")
        private val FLATS = listOf("A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab")
    }

    private val notes = when (tonic) {
        "F", "Bb", "Eb", "Ab", "Db", "Gb", "d", "g", "c", "f", "bb", "eb" -> FLATS
        else -> SHARPS
    }

    fun chromatic(): List<String> {
        val index = notes.indexOf(tonic.replaceFirstChar { it.uppercase() })
        return notes.drop(index) + notes.take(index)
    }

    fun interval(intervals: String): List<String> {
        val indexes = intervals
            .runningFold(0) { i, interval ->
                i + when (interval) {
                    'm' -> 1
                    'M' -> 2
                    'A' -> 3
                    else -> 0
                }
            }

        return chromatic().filterIndexed { i, _ -> i in indexes }
    }
}

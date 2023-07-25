private val NUCLEOTIDES = setOf('A', 'C', 'G', 'T')

class Dna(private val sequence: String) {

    init {
        require(sequence.all { NUCLEOTIDES.contains(it) })
    }

    val nucleotideCounts: Map<Char, Int>
        get() = NUCLEOTIDES.associateWith { nucleotide ->
            sequence.count { it == nucleotide }
        }
}

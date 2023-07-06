object Sieve {

    fun primesUpTo(upperBound: Int): List<Int> {
        val candidates = (2 .. upperBound).toMutableList()
        val result = mutableListOf<Int>()

        while (candidates.isNotEmpty()) {
            val prime = candidates.first()
            result.add(prime)
            candidates.removeIf { it % prime == 0 }
        }

        return result
    }
}

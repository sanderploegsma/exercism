object ETL {
    fun transform(source: Map<Int, Collection<Char>>): Map<Char, Int> =
        source
            .flatMap { (value, letters) -> letters.map { it to value } }
            .toMap()
            .mapKeys { it.key.lowercaseChar() }
}

object Flattener {
    fun flatten(source: Collection<Any?>): List<Any> = source.filterNotNull().flatMap {
        when (it) {
            is Collection<*> -> flatten(it)
            else -> listOf(it)
        }
    }
}

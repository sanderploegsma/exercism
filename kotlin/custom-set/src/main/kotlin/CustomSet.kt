class CustomSet(vararg items: Int) {

    private val items = items.toMutableSet()

    fun isEmpty(): Boolean = items.isEmpty()

    fun isSubset(other: CustomSet) = other.items.containsAll(items)

    fun isDisjoint(other: CustomSet) = intersection(other).isEmpty()

    fun contains(other: Int) = items.contains(other)

    fun intersection(other: CustomSet) = CustomSet(*items.intersect(other.items).toIntArray())

    fun add(other: Int) {
        items += other
    }

    override fun equals(other: Any?): Boolean = when (other) {
        is CustomSet -> items == other.items
        else -> false
    }

    operator fun plus(other: CustomSet) = CustomSet(*(items + other.items).toIntArray())

    operator fun minus(other: CustomSet) = CustomSet(*(items - other.items).toIntArray())

    override fun hashCode(): Int = items.hashCode()
}

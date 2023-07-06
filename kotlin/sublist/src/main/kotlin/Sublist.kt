enum class Relationship {
    EQUAL, SUBLIST, SUPERLIST, UNEQUAL
}

fun <T> List<T>.relationshipTo(other: List<T>) = when {
    this == other -> Relationship.EQUAL
    this.isSubListOf(other) -> Relationship.SUBLIST
    other.isSubListOf(this) -> Relationship.SUPERLIST
    else -> Relationship.UNEQUAL
}

private fun <T> List<T>.isSubListOf(other: List<T>): Boolean {
    if (this.size >= other.size) {
        return false
    }

    for (i in 0..other.size - this.size) {
        val sublist = other.subList(i, this.size + i)

        if (sublist == this) {
            return true
        }
    }

    return false
}

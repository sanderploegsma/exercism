fun <T> List<T>.customAppend(other: List<T>): List<T> =
    other.customFoldLeft(this) { acc, item -> acc + item }

fun List<Any>.customConcat(): List<Any> =
    customFoldLeft(listOf()) { acc, item ->
        when (item) {
            is List<*> -> acc.customAppend(item.filterNotNull().customConcat())
            else -> acc + item
        }
    }

fun <T> List<T>.customFilter(predicate: (T) -> Boolean): List<T> =
    customFoldLeft(listOf()) { acc, item -> if (predicate(item)) acc + item else acc }

val <T> List<T>.customSize: Int get() = customFoldLeft(0) { acc, _ -> acc + 1 }

fun <T, U> List<T>.customMap(transform: (T) -> U): List<U> =
    customFoldLeft(listOf()) { acc, item -> acc + transform(item) }

fun <T, U> List<T>.customFoldLeft(initial: U, f: (U, T) -> U): U =
    if (isEmpty()) initial else drop(1).customFoldLeft(f(initial, first()), f)

fun <T, U> List<T>.customFoldRight(initial: U, f: (T, U) -> U): U =
    if (isEmpty()) initial else dropLast(1).customFoldRight(f(last(), initial), f)

fun <T> List<T>.customReverse(): List<T> =
    customFoldRight(listOf()) { item, acc -> acc + item }

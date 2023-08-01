import kotlin.math.max

data class Item(val weight: Int, val value: Int)

fun knapsack(maximumWeight: Int, items: List<Item>): Int {
    val valueByWeight = mutableMapOf<Pair<Int, Int>, Int>()

    for (weight in 0..maximumWeight) {
        valueByWeight[0 to weight] = 0
    }

    for (i in items.indices) {
        valueByWeight[i to 0] = 0
    }

    for ((i, item) in items.mapIndexed { index, item -> (index + 1) to item }) {
        for (weight in 1..maximumWeight) {
            val valueWithoutItem = valueByWeight[(i - 1) to weight]!!

            if (item.weight > weight) {
                valueByWeight[i to weight] = valueWithoutItem
            } else {
                val valueWithItem = valueByWeight[(i - 1) to (weight - item.weight)]!! + item.value
                valueByWeight[i to weight] = max(valueWithoutItem, valueWithItem)
            }
        }
    }

    return valueByWeight.values.maxOf { it }
}

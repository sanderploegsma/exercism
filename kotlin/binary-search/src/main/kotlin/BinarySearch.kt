object BinarySearch {
    fun search(list: List<Int>, item: Int): Int {
        var (lo, hi) = Pair(0, list.size - 1)

        while (lo <= hi) {
            val mid = (lo + hi) / 2

            if (list[mid] == item) {
                return mid
            }

            if (list[mid] < item) {
                lo = mid + 1
            } else {
                hi = mid - 1
            }
        }

        throw NoSuchElementException()
    }
}

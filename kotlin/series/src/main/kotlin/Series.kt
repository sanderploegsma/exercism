object Series {

    fun slices(n: Int, s: String): List<List<Int>> {
        require(n > 0 && n <= s.length)
        require(s.isNotEmpty())

        return s.map { it.digitToInt() }.windowed(n, step = 1)
    }
}

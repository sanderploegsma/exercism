object SpiralMatrix {
    private enum class Direction { Up, Down, Left, Right }

    fun ofSize(size: Int): Array<IntArray> {
        val matrix = Array(size) { IntArray(size) }
        var n = 1
        var x = 0
        var y = 0
        var d = Direction.Right
        while (n <= size * size) {
            matrix[y][x] = n++

            when (d) {
                Direction.Up -> {
                    y--
                    if (y - x == 1) {
                        d = Direction.Right
                    }
                }

                Direction.Down -> {
                    y++
                    if (y == x) {
                        d = Direction.Left
                    }
                }

                Direction.Left -> {
                    x--
                    if (y + x == size - 1 && y > x) {
                        d = Direction.Up
                    }
                }

                Direction.Right -> {
                    x++
                    if (y + x == size - 1 && x > y) {
                        d = Direction.Down
                    }
                }
            }
        }
        return matrix
    }
}

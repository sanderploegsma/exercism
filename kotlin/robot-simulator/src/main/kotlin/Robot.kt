class Robot(
    var gridPosition: GridPosition = GridPosition(0, 0),
    var orientation: Orientation = Orientation.NORTH
) {
    fun simulate(instructions: String): Unit = instructions.forEach(::simulate)

    private fun simulate(instruction: Char): Unit = when (instruction) {
        'R' -> orientation = turnRight()
        'L' -> orientation = turnLeft()
        'A' -> gridPosition = advance()
        else -> throw UnsupportedOperationException()
    }

    private operator fun GridPosition.plus(other: GridPosition) = GridPosition(x + other.x, y + other.y)

    private fun turnRight(): Orientation = when (orientation) {
        Orientation.NORTH -> Orientation.EAST
        Orientation.EAST -> Orientation.SOUTH
        Orientation.SOUTH -> Orientation.WEST
        Orientation.WEST -> Orientation.NORTH
    }

    private fun turnLeft(): Orientation = when (orientation) {
        Orientation.NORTH -> Orientation.WEST
        Orientation.EAST -> Orientation.NORTH
        Orientation.SOUTH -> Orientation.EAST
        Orientation.WEST -> Orientation.SOUTH
    }

    private fun advance(): GridPosition = gridPosition + when (orientation) {
        Orientation.NORTH -> GridPosition(0, 1)
        Orientation.EAST -> GridPosition(1, 0)
        Orientation.SOUTH -> GridPosition(0, -1)
        Orientation.WEST -> GridPosition(-1, 0)
    }
}

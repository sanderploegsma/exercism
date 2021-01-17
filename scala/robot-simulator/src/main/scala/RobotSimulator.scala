object Bearing extends Enumeration {
  val North, East, South, West = Value

  implicit class BearingValue(bearing: Value) {
    def turnLeft: Bearing.Value = bearing match {
      case Bearing.North => Bearing.West
      case Bearing.West => Bearing.South
      case Bearing.South => Bearing.East
      case Bearing.East => Bearing.North
    }

    def turnRight: Bearing.Value = bearing match {
      case Bearing.North => Bearing.East
      case Bearing.East => Bearing.South
      case Bearing.South => Bearing.West
      case Bearing.West => Bearing.North
    }
  }
}

case class Robot(bearing: Bearing.Value, coordinates: (Int, Int)) {
  def turnLeft: Robot = copy(bearing = bearing.turnLeft)

  def turnRight: Robot = copy(bearing = bearing.turnRight)

  def advance: Robot = {
    val (x, y) = coordinates
    val newCoordinates = bearing match {
      case Bearing.North => (x, y + 1)
      case Bearing.East => (x + 1, y)
      case Bearing.South => (x, y - 1)
      case Bearing.West => (x - 1, y)
    }
    copy(coordinates = newCoordinates)
  }

  def simulate(instructions: String): Robot =
    instructions.foldLeft(this)(_.simulate(_))

  private def simulate(instruction: Char): Robot = instruction match {
    case 'A' => advance
    case 'L' => turnLeft
    case 'R' => turnRight
    case _ => throw new IllegalArgumentException(s"Unsupported instruction '$instruction'")
  }
}
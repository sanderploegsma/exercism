object Bearing extends Enumeration {
  val North, East, South, West = Value
}

case class Robot(bearing: Bearing.Value, coordinates: (Int, Int)) {
  def turnLeft: Robot = {
    val bearings = Seq(Bearing.North, Bearing.West, Bearing.South, Bearing.East)
    copy(bearing = nextBearing(bearings))
  }

  def turnRight: Robot = {
    val bearings = Seq(Bearing.North, Bearing.East, Bearing.South, Bearing.West)
    copy(bearing = nextBearing(bearings))
  }

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

  private def nextBearing(bearings: Seq[Bearing.Value]): Bearing.Value =
    bearings.dropWhile(_ != bearing).drop(1).headOption.getOrElse(bearings.head)

  private def simulate(instruction: Char): Robot = instruction match {
    case 'A' => advance
    case 'L' => turnLeft
    case 'R' => turnRight
    case _ => throw new IllegalArgumentException(s"Unsupported instruction '$instruction'")
  }
}
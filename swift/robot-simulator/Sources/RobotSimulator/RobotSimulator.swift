enum Direction {
  case north
  case east
  case south
  case west
}

enum Instruction: Character {
  case turnRight = "R"
  case turnLeft = "L"
  case advance = "A"
}

private let rightTurns: [Direction: Direction] = [
  .north: .east,
  .east: .south,
  .south: .west,
  .west: .north,
]

private let leftTurns = rightTurns.reduce(into: [Direction: Direction]()) { $0[$1.value] = $1.key }

class SimulatedRobot {
  private(set) var bearing: Direction = .north
  private(set) var coordinates: [Int] = [0, 0]

  func turnRight() {
    self.bearing = rightTurns[bearing]!
  }

  func turnLeft() {
    self.bearing = leftTurns[bearing]!
  }

  func advance() {
    switch bearing {
    case .north:
      self.coordinates[1] += 1
    case .east:
      self.coordinates[0] += 1
    case .south:
      self.coordinates[1] -= 1
    case .west:
      self.coordinates[0] -= 1
    }
  }

  func orient(_ direction: Direction) {
    self.bearing = direction
  }

  func at(x: Int, y: Int) {
    self.coordinates = [x, y]
  }

  func place(x: Int, y: Int, direction: Direction) {
    self.at(x: x, y: y)
    self.orient(direction)
  }

  func instructions(_ instructions: String) -> [Instruction] {
    instructions.compactMap { Instruction.init(rawValue: $0) }
  }

  func evaluate(_ instructions: String) {
    for instruction in self.instructions(instructions) {
      switch instruction {
      case .advance:
        self.advance()
      case .turnRight:
        self.turnRight()
      case .turnLeft:
        self.turnLeft()
      }
    }
  }
}

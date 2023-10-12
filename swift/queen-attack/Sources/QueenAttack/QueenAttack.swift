let bounds = 0..<8

class Queens {
  enum InitError: Error {
    case incorrectNumberOfCoordinates
    case invalidCoordinates
    case sameSpace
  }

  let white: [Int]
  let black: [Int]

  init(white: [Int] = [0, 3], black: [Int] = [7, 3]) throws {
    guard white.count == 2 else { throw InitError.incorrectNumberOfCoordinates }
    guard black.count == 2 else { throw InitError.incorrectNumberOfCoordinates }
    guard white.allSatisfy({ bounds.contains($0) }) else { throw InitError.invalidCoordinates }
    guard black.allSatisfy({ bounds.contains($0) }) else { throw InitError.invalidCoordinates }
    guard white != black else { throw InitError.sameSpace }

    self.white = white
    self.black = black
  }

  var description: String {
    bounds.map { row in
      bounds.map { col in
        if [row, col] == white {
          return "W"
        }

        if [row, col] == black {
          return "B"
        }

        return "_"
      }.joined(separator: " ")
    }.joined(separator: "\n")
  }

  var canAttack: Bool {
    let sameRow = white[0] == black[0]
    let sameColumn = white[1] == black[1]
    let sameDiagonal = abs(white[0] - white[1]) == abs(black[0] - black[1])
    return sameRow || sameColumn || sameDiagonal
  }
}

class Squares {
  private let range: ClosedRange<Int>

  init(_ limit: Int) {
    range = (1...limit)
  }

  var squareOfSum: Int {
    let sum = range.reduce(0, +)
    return sum * sum
  }

  var sumOfSquares: Int {
    range.reduce(0) { $0 + $1 * $1 }
  }

  var differenceOfSquares: Int {
    squareOfSum - sumOfSquares
  }
}

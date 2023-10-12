enum GrainsError: Error {
  case inputTooLow
  case inputTooHigh
}

private let size = 64

struct Grains {
  static func square(_ num: Int) throws -> UInt64 {
    guard num > 0 else { throw GrainsError.inputTooLow }
    guard num <= size else { throw GrainsError.inputTooHigh }
    return 1 << (num - 1)
  }

  static var total: UInt64 {
    get throws {
      UInt64.max
    }
  }
}

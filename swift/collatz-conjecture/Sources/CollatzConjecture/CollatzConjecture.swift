class CollatzConjecture {
  struct InvalidNumber: Error {}

  static func steps(_ number: Int) throws -> Int {
    guard number > 0 else {
      throw InvalidNumber()
    }

    if number == 1 {
      return 0
    }

    let nextNumber = number.isMultiple(of: 2) ? number / 2 : 3 * number + 1
    return try 1 + steps(nextNumber)
  }
}

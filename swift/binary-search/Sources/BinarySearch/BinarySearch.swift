enum BinarySearchError: Error {
  case valueNotFound
}

class BinarySearch {
  private let numbers: [Int]

  init(_ numbers: [Int]) {
    self.numbers = numbers
  }

  func searchFor(_ number: Int) throws -> Int {
    var (lo, hi) = (numbers.startIndex, numbers.endIndex - 1)

    while lo <= hi {
      let mid = (lo + hi) / 2

      if numbers[mid] == number {
        return mid
      }

      if numbers[mid] < number {
        lo = mid + 1
      } else {
        hi = mid - 1
      }
    }

    throw BinarySearchError.valueNotFound
  }
}

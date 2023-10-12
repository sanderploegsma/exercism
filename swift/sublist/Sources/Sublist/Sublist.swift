enum Classifier {
  case equal
  case sublist
  case superlist
  case unequal
}

func classifier(listOne: [Int], listTwo: [Int]) -> Classifier {
  if listOne == listTwo {
    return .equal
  }

  if listOne.windows(ofSize: listTwo.count).contains(where: { $0 == listTwo }) {
    return .superlist
  }

  if listTwo.windows(ofSize: listOne.count).contains(where: { $0 == listOne }) {
    return .sublist
  }

  return .unequal
}

extension Array {
  func windows(ofSize size: Int) -> [[Element]] {
    guard count >= size else { return [] }
    return (0..<(count - size + 1)).map { Array(self[$0..<($0 + size)]) }
  }
}

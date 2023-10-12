//Solution goes in Sources
enum Classification {
  case perfect
  case deficient
  case abundant
}

private func aliquotSumOf(number: Int) -> Int {
  (1...(number / 2))
    .filter { number.isMultiple(of: $0) }
    .reduce(0, +)
}

class NumberClassifier {
  let classification: Classification

  init(number: Int) {
    let diff = aliquotSumOf(number: number) - number
    switch diff {
    case _ where diff < 0:
      self.classification = .deficient
    case _ where diff > 0:
      self.classification = .abundant
    default:
      self.classification = .perfect
    }
  }
}

class Allergies {
  let allergens = [
    "eggs": 1,
    "peanuts": 2,
    "shellfish": 4,
    "strawberries": 8,
    "tomatoes": 16,
    "chocolate": 32,
    "pollen": 64,
    "cats": 128,
  ]

  private let mask: Int

  init(_ mask: Int) {
    self.mask = mask
  }

  func allergicTo(item: String) -> Bool {
    if let value = allergens[item] {
      return self.mask & value == value
    }

    return false
  }

  func list() -> [String] {
    allergens
      .sorted(by: { $0.value < $1.value })
      .filter { allergicTo(item: $0.key) }
      .map { $0.key }
  }
}

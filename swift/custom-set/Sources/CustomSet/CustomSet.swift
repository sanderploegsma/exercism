class CustomSet: Equatable {
  private var items: [Int] = []

  init(_ items: [Int]) {
    items.forEach(add)
  }

  var isEmpty: Bool {
    items.isEmpty
  }

  func add(_ item: Int) {
    if !contains(item) {
      items.append(item)
    }
  }

  func contains(_ item: Int) -> Bool {
    items.contains(item)
  }

  func isSubset(of other: CustomSet) -> Bool {
    items.allSatisfy(other.contains)
  }

  func isDisjoint(with other: CustomSet) -> Bool {
    items.allSatisfy({ !other.contains($0) })
  }

  func intersection(_ other: CustomSet) -> CustomSet {
    CustomSet(items.filter(other.contains))
  }

  func difference(_ other: CustomSet) -> CustomSet {
    CustomSet(items.filter { !other.contains($0) })
  }

  func union(_ other: CustomSet) -> CustomSet {
    CustomSet(items + other.items)
  }

  static func == (lhs: CustomSet, rhs: CustomSet) -> Bool {
    lhs.isSubset(of: rhs) && rhs.isSubset(of: lhs)
  }
}

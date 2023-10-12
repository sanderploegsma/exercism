extension Array {
  func keep(predicate: (Element) -> Bool) -> Array {
    var items = [Element]()
    for item in self {
      if predicate(item) {
        items.append(item)
      }
    }
    return items
  }

  func discard(predicate: (Element) -> Bool) -> Array {
    var items = [Element]()
    for item in self {
      if !predicate(item) {
        items.append(item)
      }
    }
    return items
  }
}

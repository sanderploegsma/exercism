class Element<T> {
  let value: T?
  let next: Element?

  init(_ value: T? = nil, _ next: Element? = nil) {
    self.value = value
    self.next = next
  }

  func reverseElements() -> Element<T> {
    var reversed = self
    var next = self.next

    while next != nil {
      reversed = Element(next?.value, reversed)
      next = next?.next
    }

    return reversed
  }

  func toArray() -> [T] {
    let nextArray = next?.toArray() ?? []
    if let value = self.value {
      return [value] + nextArray
    }
    return [] + nextArray
  }

  static func fromArray(_ array: [T]) -> Element<T> {
    guard let head = array.first else {
      return Element()
    }

    return Element(head, Element.fromArray(Array(array.dropFirst())))
  }
}

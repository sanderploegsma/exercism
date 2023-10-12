//Solution goes in Sources
extension Array {
  func accumulate<T>(_ f: (Element) -> T) -> [T] {
    var result = [T]()
    for item in self {
      result.append(f(item))
    }
    return result
  }
}

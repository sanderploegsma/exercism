func flattenArray(_ array: [Any?]) -> [Int] {
  var result = [Int]()
  for item in array {
    if let number = item as? Int {
      result.append(number)
    }

    if let nested = item as? [Any?] {
      result += flattenArray(nested)
    }
  }
  return result
}

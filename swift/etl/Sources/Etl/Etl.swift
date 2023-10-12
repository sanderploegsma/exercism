class ETL {
  static func transform(_ old: [String: [String]]) -> [String: Int] {
    var results = [String: Int]()

    for (key, chars) in old {
      guard let score = Int(key) else {
        continue
      }

      for char in chars {
        results[char.lowercased()] = score
      }
    }

    return results
  }
}

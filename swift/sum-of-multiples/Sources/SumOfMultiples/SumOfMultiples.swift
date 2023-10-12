func toLimit(_ limit: Int, inMultiples: [Int]) -> Int {
  (1..<limit).filter { n in
    inMultiples.contains(where: { n.isMultiple(of: $0) })
  }.reduce(0, +)
}

private let factors = [(3, "Pling"), (5, "Plang"), (7, "Plong")]

func raindrops(_ number: Int) -> String {
  let result =
    factors
    .filter { number.isMultiple(of: $0.0) }
    .map { $0.1 }
    .joined()

  return result.isEmpty ? String(number) : result
}

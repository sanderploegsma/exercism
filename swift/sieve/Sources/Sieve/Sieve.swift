private func sieve(candidates: [Int], primes: [Int]) -> [Int] {
  guard let prime = candidates.first else {
    return primes
  }

  return sieve(
    candidates: candidates.filter { !$0.isMultiple(of: prime) },
    primes: primes + [prime]
  )
}

func sieve(limit: Int) -> [Int] {
  guard limit > 1 else {
    return []
  }

  return sieve(candidates: Array(2...limit), primes: [])
}

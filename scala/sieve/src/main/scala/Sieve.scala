object Sieve {
  def primes(limit: Int): List[Int] = {
    def findPrimes(candidates: List[Int]): List[Int] = candidates.headOption match {
      case None => List()
      case Some(candidate) => candidate :: findPrimes(candidates.filter(_ % candidate != 0))
    }

    findPrimes((2 to limit).toList)
  }
}

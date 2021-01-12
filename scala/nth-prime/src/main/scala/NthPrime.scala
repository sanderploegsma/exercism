object NthPrime {
  def prime(n: Int): Option[Int] = n match {
    case 0 => None
    case _ => primes.drop(n - 1).headOption
  }

  private def primes: Seq[Int] =
    Stream.from(2).filter(isPrime)

  private def isPrime(n: Int) =
    (2 to math.sqrt(n).toInt).forall(n % _ != 0)
}
sealed trait Classification

object NumberType {
  case object Perfect extends Classification
  case object Abundant extends Classification
  case object Deficient extends Classification
}

object PerfectNumbers {
  def classify(n: Int): Either[String, Classification] = {
    if (n <= 0) {
      return Left("Classification is only possible for natural numbers.")
    }

    val factors = Range.inclusive(1, n / 2).filter { n % _ == 0 }

    val classification = factors.sum match {
      case x if x == n => NumberType.Perfect
      case x if x < n => NumberType.Deficient
      case x if x > n => NumberType.Abundant
    }

    Right(classification)
  }
}
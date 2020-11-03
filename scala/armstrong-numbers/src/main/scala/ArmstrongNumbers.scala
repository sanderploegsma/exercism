object ArmstrongNumbers {
  def isArmstrongNumber(n: Int): Boolean = {
    val digits = n.toString.split("").map(_.toInt)
    digits.map { Math.pow(_, digits.length) }.sum == n
  }
}
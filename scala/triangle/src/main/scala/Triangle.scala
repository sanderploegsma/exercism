case class Triangle(a: Double, b: Double, c: Double) {
  private val distinctSides = Seq(a, b, c).distinct

  private val isValid = {
    // all sides have to be of length > 0
    Seq(a, b, c).forall(_ > 0) &&
    // the sum of the lengths of any two sides must be greater than or equal to the length of the third side
    Seq((a, b, c), (a, c, b), (b, c, a)).forall { case (x, y, z) => x + y >= z }
  }

  def equilateral: Boolean = isValid && distinctSides.length == 1
  def isosceles: Boolean = isValid && distinctSides.length <= 2
  def scalene: Boolean = isValid && distinctSides.length == 3
}
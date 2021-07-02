case class ComplexNumber(real: Double = 0, imaginary: Double = 0) {

  /**
   * Add two complex numbers.
   *
   * This is defined as (a + i * b) + (c + i * d) = (a + c) + (b + d) * i.
   *
   * @param other The complex number to add
   * @return The sum of this complex number and the given complex number
   */
  def +(other: ComplexNumber): ComplexNumber = {
    val (a, b) = (this.real, this.imaginary)
    val (c, d) = (other.real, other.imaginary)

    ComplexNumber(
      real = a + c,
      imaginary = b + d
    )
  }

  /**
   * Subtract two complex numbers.
   *
   * This is defined as (a + i * b) - (c + i * d) = (a - c) + (b - d) * i.
   *
   * @param other The complex number to subtract
   * @return The difference between this complex number and the given complex number
   */
  def -(other: ComplexNumber): ComplexNumber = {
    val (a, b) = (this.real, this.imaginary)
    val (c, d) = (other.real, other.imaginary)

    ComplexNumber(
      real = a - c,
      imaginary = b - d
    )
  }

  /**
   * Multiply two complex numbers.
   *
   * This is defined as (a + i * b) * (c + i * d) = (a * c - b * d) + (b * c + a * d) * i.
   *
   * @param other The complex number to multiply with
   * @return The product of this complex number and the given complex number
   */
  def *(other: ComplexNumber): ComplexNumber = {
    val (a, b) = (this.real, this.imaginary)
    val (c, d) = (other.real, other.imaginary)

    ComplexNumber(
      real = a * c - b * d,
      imaginary = b * c + a * d
    )
  }

  /**
   * Divide two complex numbers.
   *
   * This is defined as (a + i * b) / (c + i * d) = (a * c + b * d)/(c^2 + d^2) + (b * c - a * d)/(c^2 + d^2) * i.
   *
   * @param other The complex number to divide by
   * @return The fraction of this complex number and the given complex number
   */
  def /(other: ComplexNumber): ComplexNumber = {
    val (a, b) = (this.real, this.imaginary)
    val (c, d) = (other.real, other.imaginary)

    ComplexNumber(
      real = (a * c + b * d) / (math.pow(c, 2) + math.pow(d, 2)),
      imaginary = (b * c - a * d) / (math.pow(c, 2) + math.pow(d, 2))
    )
  }

  /**
   * Calculate the absolute value of this complex number.
   *
   * This is defined as |z| = sqrt(a^2 + b^2).
   *
   * @return The absolute value of this complex number
   */
  def abs: Double = math.sqrt(math.pow(this.real, 2) + math.pow(this.imaginary, 2))

  /**
   * Calculate the conjugate of this complex number.
   *
   * This is defined as z = a - b * i.
   *
   * @return The conjugate of this complex number
   */
  def conjugate: ComplexNumber = ComplexNumber(
    real = this.real,
    imaginary = this.imaginary * -1
  )
}

object ComplexNumber {
  /**
   * Raise e to the given complex number.
   *
   * This is defined as e^(a + i * b) = e^a * e^(i * b),
   * the last term of which is given by Euler's formula e^(i * b) = cos(b) + i * sin(b).
   *
   * @param number The complex number to raise e to
   * @return e raised to the given complex number
   */
  def exp(number: ComplexNumber): ComplexNumber = {
    val (a, b) = (number.real, number.imaginary)

    ComplexNumber(
      real = math.pow(math.E, a) * math.cos(b),
      imaginary = math.pow(math.E, a) * math.sin(b)
    )
  }
}
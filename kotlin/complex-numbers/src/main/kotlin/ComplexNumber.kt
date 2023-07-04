import kotlin.math.*

data class ComplexNumber(val real: Double = 0.0, val imag: Double = 0.0) {
    operator fun plus(other: ComplexNumber) =
            ComplexNumber(this.real + other.real, this.imag + other.imag)

    operator fun minus(other: ComplexNumber) =
            ComplexNumber(this.real - other.real, this.imag - other.imag)

    operator fun times(other: ComplexNumber): ComplexNumber {
        val real = this.real * other.real - this.imag * other.imag
        val imag = this.imag * other.real + this.real * other.imag
        return ComplexNumber(real, imag)
    }

    operator fun div(other: ComplexNumber): ComplexNumber {
        val denominator = other.real * other.real + other.imag * other.imag
        val real = (this.real * other.real + this.imag * other.imag) / denominator
        val imag = (this.imag * other.real - this.real * other.imag) / denominator
        return ComplexNumber(real, imag)
    }

    val abs = sqrt(real * real + imag * imag)

    fun conjugate() = ComplexNumber(real, -imag)
}

fun exponential(z: ComplexNumber): ComplexNumber {
    val real = exp(z.real) * cos(z.imag)
    val imag = exp(z.real) * sin(z.imag)
    return ComplexNumber(real, imag)
}

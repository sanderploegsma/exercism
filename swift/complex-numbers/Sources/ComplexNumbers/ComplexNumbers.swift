import Foundation

struct ComplexNumber {
  let realComponent: Double
  let imaginaryComponent: Double

  init(realComponent: Double, imaginaryComponent: Double) {
    self.realComponent = realComponent
    self.imaginaryComponent = imaginaryComponent
  }

  func getRealComponent() -> Double {
    self.realComponent
  }

  func getImaginaryComponent() -> Double {
    self.imaginaryComponent
  }

  func add(complexNumber other: ComplexNumber) -> ComplexNumber {
    let a = self.realComponent
    let b = self.imaginaryComponent
    let c = other.realComponent
    let d = other.imaginaryComponent
    return ComplexNumber(realComponent: a + c, imaginaryComponent: b + d)
  }

  func subtract(complexNumber other: ComplexNumber) -> ComplexNumber {
    let a = self.realComponent
    let b = self.imaginaryComponent
    let c = other.realComponent
    let d = other.imaginaryComponent
    return ComplexNumber(realComponent: a - c, imaginaryComponent: b - d)
  }

  func multiply(complexNumber other: ComplexNumber) -> ComplexNumber {
    let a = self.realComponent
    let b = self.imaginaryComponent
    let c = other.realComponent
    let d = other.imaginaryComponent
    return ComplexNumber(realComponent: a * c - b * d, imaginaryComponent: b * c + a * d)
  }

  func divide(complexNumber other: ComplexNumber) -> ComplexNumber {
    let a = self.realComponent
    let b = self.imaginaryComponent
    let c = other.realComponent
    let d = other.imaginaryComponent
    return ComplexNumber(
      realComponent: (a * c + b * d) / (c * c + d * d),
      imaginaryComponent: (b * c - a * d) / (c * c + d * d)
    )
  }

  func absolute() -> Double {
    let a = self.realComponent
    let b = self.imaginaryComponent
    return (a * a + b * b).squareRoot()
  }

  func conjugate() -> ComplexNumber {
    let a = self.realComponent
    let b = self.imaginaryComponent
    return ComplexNumber(realComponent: a, imaginaryComponent: -b)
  }

  func exponent() -> ComplexNumber {
    let a = self.realComponent
    let b = self.imaginaryComponent
    let e = exp(1.0)
    return ComplexNumber(realComponent: pow(e, a) * cos(b), imaginaryComponent: pow(e, a) * sin(b))
  }
}

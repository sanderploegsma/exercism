class Triangle {
  let a: Double
  let b: Double
  let c: Double

  init(_ sides: [Double]) {
    assert(sides.count == 3)
    self.a = sides[0]
    self.b = sides[1]
    self.c = sides[2]
  }

  var isTriangle: Bool {
    [a, b, c].allSatisfy({ $0 > 0 }) && a + b >= c && a + c >= b && b + c >= a
  }

  var isEquilateral: Bool {
    isTriangle && Set([a, b, c]).count == 1
  }

  var isScalene: Bool {
    isTriangle && Set([a, b, c]).count == 3
  }

  var isIsosceles: Bool {
    isTriangle && !isScalene
  }
}

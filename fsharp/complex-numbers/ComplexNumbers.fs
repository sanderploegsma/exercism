module ComplexNumbers

open System

type ComplexNumber = float * float

let create real imaginary: ComplexNumber = (real, imaginary)

// Multiplication result is by definition (a + i * b) * (c + i * d) = (a * c - b * d) + (b * c + a * d) * i.
let mul z1 z2: ComplexNumber =
    let (a, b) = z1
    let (c, d) = z2
    (a * c - b * d, b * c + a * d)

// The sum/difference of two complex numbers involves adding/subtracting their real and imaginary parts separately:
// (a + i * b) + (c + i * d) = (a + c) + (b + d) * i, (a + i * b) - (c + i * d) = (a - c) + (b - d) * i.
let add z1 z2: ComplexNumber =
    let (a, b) = z1
    let (c, d) = z2
    (a + c, b + d)

// The sum/difference of two complex numbers involves adding/subtracting their real and imaginary parts separately:
// (a + i * b) + (c + i * d) = (a + c) + (b + d) * i, (a + i * b) - (c + i * d) = (a - c) + (b - d) * i.
let sub z1 z2: ComplexNumber =
    let (a, b) = z1
    let (c, d) = z2
    (a - c, b - d)

// Dividing a complex number a + i * b by another c + i * d gives: 
// (a + i * b) / (c + i * d) = (a * c + b * d)/(c^2 + d^2) + (b * c - a * d)/(c^2 + d^2) * i.
let div z1 z2 =
    let (a, b) = z1
    let (c, d) = z2
    let div = c ** 2.0 + d ** 2.0
    ((a * c + b * d) / div, (b * c - a * d) / div)

// The absolute value of a complex number z = a + b * i is a real number |z| = sqrt(a^2 + b^2).
let abs (z: ComplexNumber) = 
    let (a, b) = z
    sqrt (a * a + b * b)

// The conjugate of the number a + b * i is the number a - b * i.
let conjugate z =
    let (a, b) = z
    (a, b * -1.0)

let real z =
    let (a, _) = z
    a

let imaginary z =
    let (_, b) = z
    b

// Raising e to a complex exponent can be expressed as e^(a + i * b) = e^a * e^(i * b), 
// the last term of which is given by Euler's formula e^(i * b) = cos(b) + i * sin(b).
let exp z =
    let (a, b) = z
    let c = Math.E ** a
    (c * Math.Cos(b), c * Math.Sin(b))
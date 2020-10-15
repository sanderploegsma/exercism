module RationalNumbers

let rec gcd a b = if b = 0 then a else gcd b (a % b)

let create numerator denominator =
    let gcd = gcd numerator denominator
    (numerator / gcd, denominator / gcd)

// The sum of two rational numbers r1 = a1/b1 and r2 = a2/b2
// is r1 + r2 = a1/b1 + a2/b2 = (a1 * b2 + a2 * b1) / (b1 * b2).
let add r1 r2 =
    let (a1, b1) = r1
    let (a2, b2) = r2
    (a1 * b2 + a2 * b1, b1 * b2)

// The difference of two rational numbers r1 = a1/b1 and r2 = a2/b2
// is r1 - r2 = a1/b1 - a2/b2 = (a1 * b2 - a2 * b1) / (b1 * b2).
let sub r1 r2 = 
    let (a1, b1) = r1
    let (a2, b2) = r2
    (a1 * b2 - a2 * b1, b1 * b2)

// The product (multiplication) of two rational numbers r1 = a1/b1 and r2 = a2/b2
// is r1 * r2 = (a1 * a2) / (b1 * b2).
let mul r1 r2 =
    let (a1, b1) = r1
    let (a2, b2) = r2
    (a1 * a2, b1 * b2)

// Dividing a rational number r1 = a1/b1 by another r2 = a2/b2 
// is r1 / r2 = (a1 * b2) / (a2 * b1) if a2 * b1 is not zero.
let div r1 r2 =
    let (a1, b1) = r1
    let (a2, b2) = r2
    (a1 * b2, a2 * b1)

// The absolute value |r| of the rational number r = a/b is equal to |a|/|b|.
let abs r =
    let (a, b) = r
    (abs a) / (abs b)

// Exponentiation of a rational number r = a/b to a non-negative integer power n 
// is r^n = (a^n)/(b^n).
// Exponentiation of a rational number r = a/b to a negative integer power n 
// is r^n = (b^m)/(a^m), where m = |n|.
let exprational n r =
    let (a, b) = r
    if n >= 0 then
        (pown a n, pown b n)
    else
        let m = n * -1
        (pown b m, pown a m)

// Exponentiation of a real number x to a rational number r = a/b
// is x^(a/b) = root(x^a, b), where root(p, q) is the qth root of p.
let expreal r n =
    let (a, b) = r
    pown (pown n a) (1 / b)

let reduce r = r
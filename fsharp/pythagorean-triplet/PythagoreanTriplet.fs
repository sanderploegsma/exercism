module PythagoreanTriplet

let tripletsWithSum sum =
    let isPythagorean a b c = a < b && b < c && a * a + b * b = c * c

    [ for a in 0 .. sum / 3 do
          for b in 0 .. sum / 2 do
              let c = sum - b - a

              if isPythagorean a b c then
                  yield (a, b, c) ]

module SaddlePoints

let saddlePoints matrix =
    let m = array2D matrix

    let isSaddlePoint row col =
        let value = Array2D.get m row col
        (m.[*, col] |> Array.forall ((<=) value)) &&
        (m.[row, *] |> Array.forall ((>=) value))

    [ for row in 0 .. Array2D.length1 m - 1 do
          for col in 0 .. Array2D.length2 m - 1 do
              if isSaddlePoint row col then
                  yield row + 1, col + 1 ]

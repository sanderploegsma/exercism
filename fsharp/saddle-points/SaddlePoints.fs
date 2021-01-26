module SaddlePoints

let saddlePoints (matrix: int list list) =
    let maxInRow = lazy (matrix |> List.map List.max)

    let minInCol =
        lazy (matrix |> List.transpose |> List.map List.min)

    let isSaddlePoint row col =
        let value = matrix.[row].[col]

        value = maxInRow.Force().[row]
        && value = minInCol.Force().[col]

    [ for row in 0 .. List.length matrix - 1 do
          for col in 0 .. List.length (List.head matrix) - 1 do
              if isSaddlePoint row col then
                  yield row + 1, col + 1 ]

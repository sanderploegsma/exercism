module Matrix

let private parse (matrix: string) =
    matrix.Split("\n")
    |> Array.map (fun s -> s.Split(" "))
    |> array2D
    |> Array2D.map int

// https://stackoverflow.com/a/2369690/1595197
let private flatten (values: 'a[,]) = 
    values
    |> Seq.cast<'a>
    |> Seq.toList

let row index matrix =
    parse matrix
    |> fun m -> m.[index - 1 .. index - 1, *]
    |> flatten

let column index matrix =
    parse matrix
    |> fun m -> m.[*, index - 1 .. index - 1]
    |> flatten

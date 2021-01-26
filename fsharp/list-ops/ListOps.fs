module ListOps

let rec foldl folder state list =
    match list with
    | [] -> state
    | head :: tail -> foldl folder (folder state head) tail

let rec foldr folder state list =
    match list with
    | [] -> state
    | head :: tail -> folder head (foldr folder state tail)

let length list =
    list |> foldl (fun count _ -> count + 1) 0

let reverse list =
    list |> foldl (fun tail x -> x :: tail) []

let map f list =
    list |> foldr (fun x tail -> f x :: tail) []

let filter f list =
    list
    |> foldr (fun x tail -> if f x then x :: tail else tail) []

let append xs ys = foldr (fun x tail -> x :: tail) ys xs

let concat xs = xs |> foldr append []

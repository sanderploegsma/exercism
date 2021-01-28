module DotDsl

type Child =
    | Attr of string * string
    | Node of string * (string * string) list
    | Edge of string * string * (string * string) list

let graph (children: Child list) =
    let sortKey =
        function
        | Attr (key, _) -> key
        | Node (key, _) -> key
        | Edge (left, _, _) -> left

    children |> List.sortBy sortKey

let attr key value = Attr (key, value)
let node key attrs = Node (key, attrs)
let edge left right attrs = Edge (left, right, attrs)

let attrs = List.filter (function | Attr _ -> true | _ -> false)
let nodes = List.filter (function | Node _ -> true | _ -> false)
let edges = List.filter (function | Edge _ -> true | _ -> false)
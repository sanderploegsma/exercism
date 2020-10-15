module BinarySearchTree

type Node = { value: int; left: Node option; right: Node option }

let rec insert (tree: Node option) (value: int): Node =
    match tree with
    | None -> { value=value; left=None; right=None; }
    | Some t when value > t.value -> { t with right=Some (insert t.right value) }
    | Some t -> { t with left=Some (insert t.left value) }

let rec sort (tree: Node option): int list =
    match tree with
    | None -> []
    | Some node -> (sort node.left) @ [node.value] @ (sort node.right)

let left node = node.left

let right node = node.right

let data node = node.value

let create (items: int list): Node = 
    items
    |> List.fold (fun acc item -> Some (insert acc item)) None
    |> Option.get

let sortedData node = node |> Some |> sort
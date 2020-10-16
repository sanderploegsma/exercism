module CustomSet

let empty = List.empty

let singleton = List.singleton

let isEmpty = List.isEmpty

let size = List.length

let contains = List.contains

let insert value set = 
    let rec insertValue _set =
        match _set with
        | [] -> [value]
        | head :: tail when head = value -> [head] @ tail
        | head :: tail -> [head] @ insertValue tail
    insertValue set

let fromList list = 
    list 
    |> List.fold (fun acc cur -> insert cur acc) empty

let toList set = set

let union left right = 
    List.append left right 
    |> fromList

let intersection left right =
    List.append left right 
    |> List.filter (fun x -> contains x left) 
    |> List.filter (fun x -> contains x right)

let difference left right = 
    left
    |> List.filter (fun x -> not (contains x right))

let isSubsetOf left right = 
    left 
    |> List.forall (fun x -> contains x right)

let isDisjointFrom left right = 
    List.allPairs left right 
    |> List.forall (fun (a, b) -> a <> b)

let isEqualTo left right = isSubsetOf left right && isSubsetOf right left
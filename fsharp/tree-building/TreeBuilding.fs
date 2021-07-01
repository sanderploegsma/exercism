// This is the file you need to modify for your own solution.
// The unit tests will use this code, and it will be used by the benchmark tests
// for the "Mine" row of the summary table.

// Remember to not only run the unit tests for this exercise, but also the
// benchmark tests using `dotnet run -c Release`.
// Please refer to the instructions for more information about the benchmark tests.

module TreeBuilding

open TreeBuildingTypes

type Tree =
    | Branch of int * Tree list
    | Leaf of int

let recordId t =
    match t with
    | Branch (id, c) -> id
    | Leaf id -> id

let isBranch t =
    match t with
    | Branch (id, c) -> true
    | Leaf id -> false

let children t =
    match t with
    | Branch (id, c) -> c
    | Leaf id -> []

let private isChildOf child parent = child.ParentId = parent.RecordId

let rec buildSubtree records root =
    match List.filter (isChildOf root) records with
    | [] -> Leaf root.RecordId
    | xs ->
        let children =
            xs
            |> List.map (buildSubtree records)
            |> List.sortBy recordId

        Branch(root.RecordId, children)

let buildTree records =
    match List.sortBy (fun r -> r.RecordId) records with
    | [] -> failwith "Cannot build tree from empty records"
    | xs when
        xs
        |> List.indexed
        |> List.exists (fun (i, r) -> r.RecordId <> i) -> failwith "Invalid record identifiers found"
    | _ :: children when
        children
        |> List.exists (fun r -> r.ParentId >= r.RecordId) -> failwith "Invalid parent identifiers found"
    | root :: _ when isChildOf root root |> not -> failwith "Invalid root node"
    | root :: children -> buildSubtree children root

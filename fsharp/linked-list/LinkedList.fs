module LinkedList

type Node<'a> =
    { Value: 'a
      mutable Next: Node<'a> option
      mutable Previous: Node<'a> option }

type LinkedList<'a> =
    { mutable FirstNode: Node<'a> option
      mutable LastNode: Node<'a> option }

let mkLinkedList () = { FirstNode = None; LastNode = None }

let pop linkedList =
    let lastNode = Option.get linkedList.LastNode
    linkedList.LastNode <- lastNode.Previous
    lastNode.Value

let shift linkedList =
    let firstNode = Option.get linkedList.FirstNode
    linkedList.FirstNode <- firstNode.Next
    firstNode.Value

let push newValue linkedList =
    let lastNode = linkedList.LastNode

    linkedList.LastNode <-
        Some
            { Value = newValue
              Previous = lastNode
              Next = None }

    linkedList.FirstNode <-
        linkedList.FirstNode
        |> Option.orElse linkedList.LastNode

    lastNode
    |> Option.iter (fun node -> node.Next <- linkedList.LastNode)

let unshift newValue linkedList =
    let firstNode = linkedList.FirstNode

    linkedList.FirstNode <-
        Some
            { Value = newValue
              Next = firstNode
              Previous = None }

    linkedList.LastNode <-
        linkedList.LastNode
        |> Option.orElse linkedList.FirstNode

    firstNode
    |> Option.iter (fun node -> node.Previous <- linkedList.FirstNode)

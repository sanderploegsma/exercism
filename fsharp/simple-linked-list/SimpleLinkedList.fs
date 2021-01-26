module SimpleLinkedList

type LinkedList<'a> =
    | Nil
    | Cons of head: 'a * next: LinkedList<'a>

let nil = Nil

let create x n = Cons(x, n)

let isNil x = x = Nil

let next =
    function
    | Nil -> invalidOp "Nil has no next"
    | Cons (_, next) -> next

let datum =
    function
    | Nil -> invalidOp "Nil has no value"
    | Cons (x, _) -> x

let rec toList =
    function
    | Nil -> []
    | Cons (x, next) -> x :: toList next

let fromList xs = List.foldBack create xs Nil

let reverse x = x |> toList |> List.rev |> fromList
module QueenAttack

let create (position: int * int) = match position with
    | (x, y) when x < 0 || y < 0 -> false
    | (x, y) when x > 7 || y > 7 -> false
    | _ -> true

let canAttack (queen1: int * int) (queen2: int * int) = match (queen1, queen2) with
    | ((x1, _), (x2, _)) when x1 = x2 -> true
    | ((_, y1), (_, y2)) when y1 = y2 -> true
    | ((x1, y1), (x2, y2)) when (abs (x1 - x2)) = (abs (y1 - y2)) -> true
    | _ -> false
module RobotSimulator

type Direction =
    | North
    | East
    | South
    | West

type Position = int * int

let (+) ((x1, y1): Position) ((x2, y2): Position) = (x1 + x2, y1 + y2)

type Robot =
    { direction: Direction
      position: Position }

let create direction position =
    { direction = direction
      position = position }

let rightTurns =
    [ North; East; South; West; North ]
    |> List.pairwise
    |> Map.ofList

let leftTurns =
    [ North; West; South; East; North ]
    |> List.pairwise
    |> Map.ofList

let movement =
    function
    | North -> (0, 1)
    | East -> (1, 0)
    | South -> (0, -1)
    | West -> (-1, 0)

let step robot instruction =
    match instruction with
    | 'R' ->
        { robot with
              direction = rightTurns.[robot.direction] }
    | 'L' ->
        { robot with
              direction = leftTurns.[robot.direction] }
    | 'A' ->
        { robot with
              position = robot.position + movement robot.direction }
    | _ -> invalidOp "Valid instructions are 'L', 'R' and 'A'"

let move instructions robot = Seq.fold step robot instructions

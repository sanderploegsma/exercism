module RobotName

open System

let mutable usedNames = []

let generate () =
    let rnd = Random()
    let randomChar min max = rnd.Next(int min, int max) |> char

    let name =
        Seq.initInfinite
            (fun _ ->
                String.Concat [ randomChar 'A' 'Z'
                                randomChar 'A' 'Z'
                                randomChar '0' '9'
                                randomChar '0' '9'
                                randomChar '0' '9' ])
        |> Seq.skipWhile (fun name -> List.contains name usedNames)
        |> Seq.head

    usedNames <- name :: usedNames
    name

type Robot = { Name: string }

let mkRobot () = { Name = generate () }

let name robot = robot.Name

let reset robot = 
    usedNames <- List.except [robot.Name] usedNames
    { robot with Name = generate () }

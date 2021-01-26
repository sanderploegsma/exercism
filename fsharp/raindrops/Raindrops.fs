module Raindrops

let convert (number: int) =
    [(3, "Pling"); (5, "Plang"); (7, "Plong")]
    |> List.filter (fun (d, _) -> number % d = 0)
    |> List.map snd
    |> function
       | [] -> string number
       | sounds -> String.concat "" sounds
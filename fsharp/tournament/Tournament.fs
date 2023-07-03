module Tournament

type Result =
    | Win
    | Draw
    | Loss

type Stats =
    { Wins: int
      Losses: int
      Draws: int }

    member this.Matches = this.Wins + this.Losses + this.Draws

    member this.Points = 3 * this.Wins + this.Draws

let mapSnd f (a, b) = a, f b

let formatLine = sprintf "%-30s | %2s | %2s | %2s | %2s | %2s"

let header = formatLine "Team" "MP" "W" "D" "L" "P"

let resultsToStats results =
    let updateStats stats outcome =
        match outcome with
        | Win -> { stats with Wins = stats.Wins + 1 }
        | Loss -> { stats with Losses = stats.Losses + 1 }
        | Draw -> { stats with Draws = stats.Draws + 1 }

    results |> List.fold updateStats { Wins = 0; Draws = 0; Losses = 0 }

let tally input =
    let teamResults =
        input
        |> List.map (fun s -> (s: string).Split(";"))
        |> List.collect (function
            | [| team1; team2; "win" |] -> [ (team1, Win); (team2, Loss) ]
            | [| team1; team2; "loss" |] -> [ (team1, Loss); (team2, Win) ]
            | [| team1; team2; "draw" |] -> [ (team1, Draw); (team2, Draw) ]
            | _ -> [])
        |> List.groupBy fst
        |> List.map (mapSnd (List.map snd))

    let teamStats =
        teamResults
        |> List.map (mapSnd resultsToStats)
        |> List.sortBy (fun (team, stats) -> -stats.Points, team)
        |> List.map (fun (team, stats) ->
            formatLine
                team
                (string stats.Matches)
                (string stats.Wins)
                (string stats.Draws)
                (string stats.Losses)
                (string stats.Points))

    header :: teamStats

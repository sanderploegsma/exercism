module LogLevels

let message (logLine: string) : string =
    logLine.Split(':') |> Array.last |> (fun s -> s.Trim())

let logLevel (logLine: string) : string =
    logLine.Split(':')
    |> Array.head
    |> fun s -> s.Replace("[", "")
    |> fun s -> s.Replace("]", "")
    |> fun s -> s.ToLowerInvariant()

let reformat (logLine: string) : string =
    sprintf "%s (%s)" (message logLine) (logLevel logLine)

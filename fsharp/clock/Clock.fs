module Clock

type Clock = { minutes: int }

let rollOver minutes =
    let max = 24 * 60
    (minutes % max + max) % max

let create hours minutes =
    { minutes = 60 * hours + minutes |> rollOver }

let add minutes clock =
    { minutes = clock.minutes + minutes |> rollOver }

let subtract minutes clock =
    { minutes = clock.minutes - minutes |> rollOver }

let display clock =
    let hours = clock.minutes / 60
    let minutes = clock.minutes % 60
    sprintf "%02d:%02d" hours minutes

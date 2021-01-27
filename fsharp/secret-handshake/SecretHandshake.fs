module SecretHandshake

type Command =
    | Wink = 1
    | DoubleBlink = 2
    | CloseYourEyes = 4
    | Jump = 8
    | Reverse = 16

let (|HasFlag|_|) (flag: Command) n =
    if n &&& (int flag) > 0 then
        Some HasFlag
    else
        None

let commands number =
    let isActive command =
        match number with
        | HasFlag command -> true
        | _ -> false

    let activeCommands =
        [ Command.Wink, "wink"
          Command.DoubleBlink, "double blink"
          Command.CloseYourEyes, "close your eyes"
          Command.Jump, "jump" ]
        |> List.filter (fst >> isActive)
        |> List.map snd

    match number with
    | HasFlag Command.Reverse -> List.rev activeCommands
    | _ -> activeCommands

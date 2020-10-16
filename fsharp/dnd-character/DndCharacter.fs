module DndCharacter

open System

let modifier x = 
    let calc a = (a - 10.0) / 2.0
    x |> float |> calc |> floor |> int

let ability() = 
    let rnd = Random()
    List.init 4 (fun _ -> rnd.Next(1, 6)) 
    |> List.sortDescending 
    |> List.take 3 
    |> List.sum

type Character = {
    Strength: int;
    Dexterity: int;
    Constitution: int;
    Intelligence: int;
    Wisdom: int;
    Charisma: int;
    Hitpoints: int;
}

let createCharacter() =
    let constitution = ability()
    let hp = 10 + modifier constitution
    { 
        Strength=ability(); 
        Dexterity=ability(); 
        Constitution=constitution; 
        Intelligence=ability(); 
        Wisdom=ability(); 
        Charisma=ability(); 
        Hitpoints=hp
    }

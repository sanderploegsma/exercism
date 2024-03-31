import gleam/option.{type Option, None, Some}
import gleam/int

pub type Player {
  Player(name: Option(String), level: Int, health: Int, mana: Option(Int))
}

pub fn introduce(player: Player) -> String {
  case player.name {
    Some(name) -> name
    None -> "Mighty Magician"
  }
}

pub fn revive(player: Player) -> Option(Player) {
  case player {
    Player(health: 0, level: level, ..) if level >= 10 ->
      Player(..player, health: 100, mana: Some(100))
      |> Some
    Player(health: 0, ..) ->
      Player(..player, health: 100)
      |> Some
    _ -> None
  }
}

pub fn cast_spell(player: Player, cost: Int) -> #(Player, Int) {
  case player {
    Player(mana: Some(mana), ..) if mana < cost -> #(player, 0)
    Player(mana: Some(mana), ..) -> #(
      Player(..player, mana: Some(mana - cost)),
      2 * cost,
    )
    Player(mana: None, ..) -> #(
      Player(..player, health: int.max(player.health - cost, 0)),
      0,
    )
  }
}

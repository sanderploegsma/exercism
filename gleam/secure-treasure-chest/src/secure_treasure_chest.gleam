import gleam/string

pub opaque type TreasureChest(treasure) {
  TreasureChest(password: String, treasure: treasure)
}

pub fn create(
  password: String,
  contents: treasure,
) -> Result(TreasureChest(treasure), String) {
  case string.length(password) {
    n if n < 8 -> Error("Password must be at least 8 characters long")
    _ -> Ok(TreasureChest(password: password, treasure: contents))
  }
}

pub fn open(
  chest: TreasureChest(treasure),
  password: String,
) -> Result(treasure, String) {
  case chest {
    TreasureChest(password: p, treasure: t) if p == password -> Ok(t)
    _ -> Error("Incorrect password")
  }
}

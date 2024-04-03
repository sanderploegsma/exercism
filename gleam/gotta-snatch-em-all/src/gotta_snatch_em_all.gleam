import gleam/set.{type Set}
import gleam/list
import gleam/string
import gleam/result

pub fn new_collection(card: String) -> Set(String) {
  set.from_list([card])
}

pub fn add_card(collection: Set(String), card: String) -> #(Bool, Set(String)) {
  #(set.contains(collection, card), set.insert(collection, card))
}

pub fn trade_card(
  my_card: String,
  their_card: String,
  collection: Set(String),
) -> #(Bool, Set(String)) {
  let new_collection =
    collection
    |> set.delete(my_card)
    |> set.insert(their_card)

  let is_ok =
    set.contains(collection, my_card) && !set.contains(collection, their_card)

  #(is_ok, new_collection)
}

pub fn boring_cards(collections: List(Set(String))) -> List(String) {
  collections
  |> list.reduce(set.intersection)
  |> result.map(set.to_list)
  |> result.unwrap([])
}

pub fn total_cards(collections: List(Set(String))) -> Int {
  collections
  |> list.fold(set.new(), set.union)
  |> set.size
}

pub fn shiny_cards(collection: Set(String)) -> Set(String) {
  set.filter(collection, string.starts_with(_, "Shiny "))
}

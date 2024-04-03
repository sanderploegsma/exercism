import gleam/pair
import gleam/list

pub fn place_location_to_treasure_location(
  place_location: #(String, Int),
) -> #(Int, String) {
  pair.swap(place_location)
}

pub fn treasure_location_matches_place_location(
  place_location: #(String, Int),
  treasure_location: #(Int, String),
) -> Bool {
  place_location_to_treasure_location(place_location) == treasure_location
}

pub fn count_place_treasures(
  place: #(String, #(String, Int)),
  treasures: List(#(String, #(Int, String))),
) -> Int {
  treasures
  |> list.map(pair.second)
  |> list.filter(treasure_location_matches_place_location(place.1, _))
  |> list.length
}

pub fn special_case_swap_possible(
  found_treasure: #(String, #(Int, String)),
  place: #(String, #(String, Int)),
  desired_treasure: #(String, #(Int, String)),
) -> Bool {
  case #(place.0, found_treasure.0, desired_treasure.0) {
    #("Abandoned Lighthouse", "Brass Spyglass", _) -> True
    #("Stormy Breakwater", "Amethyst Octopus", "Crystal Crab") -> True
    #("Stormy Breakwater", "Amethyst Octopus", "Glass Starfish") -> True
    #(
      "Harbor Managers Office",
      "Vintage Pirate Hat",
      "Model Ship in Large Bottle",
    ) -> True
    #(
      "Harbor Managers Office",
      "Vintage Pirate Hat",
      "Antique Glass Fishnet Float",
    ) -> True
    _ -> False
  }
}

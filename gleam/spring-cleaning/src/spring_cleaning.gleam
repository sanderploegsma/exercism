import gleam/string

pub fn extract_error(problem: Result(a, b)) -> b {
  let assert Error(error) = problem
  error
}

pub fn remove_team_prefix(team: String) -> String {
  let assert Ok(#(_, team_name)) = string.split_once(team, " ")
  team_name
}

pub fn split_region_and_team(combined: String) -> #(String, String) {
  let assert Ok(#(region, team)) = string.split_once(combined, ",")
  #(region, remove_team_prefix(team))
}

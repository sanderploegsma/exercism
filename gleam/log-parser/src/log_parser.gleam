import gleam/regex.{Match}
import gleam/option.{Some}

pub fn is_valid_line(line: String) -> Bool {
  let assert Ok(pattern) =
    regex.from_string("^\\[(?:DEBUG|INFO|WARNING|ERROR)\\]")
  regex.check(pattern, line)
}

pub fn split_line(line: String) -> List(String) {
  let assert Ok(pattern) = regex.from_string("<[~\\*=\\-]*>")
  regex.split(pattern, line)
}

pub fn tag_with_user_name(line: String) -> String {
  let assert Ok(pattern) = regex.from_string("User\\s+(\\S+)")
  case regex.scan(pattern, line) {
    [Match(submatches: [Some(user)], ..)] -> "[USER] " <> user <> " " <> line
    _ -> line
  }
}

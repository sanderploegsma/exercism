import gleam/string

fn parse(log_line: String) -> #(String, String) {
  let assert [level, message] = string.split(log_line, on: ":")
  #(
    level
      |> string.drop_left(1)
      |> string.drop_right(1)
      |> string.lowercase,
    message
      |> string.trim,
  )
}

pub fn message(log_line: String) -> String {
  parse(log_line).1
}

pub fn log_level(log_line: String) -> String {
  parse(log_line).0
}

pub fn reformat(log_line: String) -> String {
  let #(level, message) = parse(log_line)
  message <> " (" <> level <> ")"
}

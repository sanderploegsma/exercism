import gleam/string
import gleam/result
import gleam/list

pub fn first_letter(name: String) {
  name
  |> string.trim
  |> string.first
  |> result.unwrap("")
}

pub fn initial(name: String) {
  name
  |> first_letter
  |> string.uppercase
  |> string.append(suffix: ".")
}

pub fn initials(full_name: String) {
  full_name
  |> string.split(" ")
  |> list.map(initial)
  |> string.join(" ")
}

pub fn pair(full_name1: String, full_name2: String) {
  let value =
    [full_name1, full_name2]
    |> list.map(initials)
    |> string.join("  +  ")

  "
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     " <> value <> "     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
"
}

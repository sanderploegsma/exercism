module WordCount

open System.Text.RegularExpressions

let countWords (phrase: string) =
    let pattern = @"\w+'\w+|\w+"
    [for m in Regex.Matches(phrase, pattern) -> m.Value.ToLower()]
    |> List.countBy id
    |> Map.ofList
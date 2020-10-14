module Pangram

let alphabet = "abcdefghijklmnopqrstuvwxyz"

let isPangram (input: string): bool = alphabet |> Seq.forall (fun c -> Seq.contains c (input.ToLowerInvariant()))
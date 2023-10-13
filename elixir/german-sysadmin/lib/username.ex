defmodule Username do
  def sanitize(~c""), do: ~c""

  def sanitize([head | tail]) do
    sanitize_character(head) ++ sanitize(tail)
  end

  defp sanitize_character(character) do
    case character do
      ?_ -> ~c"_"
      ?ä -> ~c"ae"
      ?ö -> ~c"oe"
      ?ü -> ~c"ue"
      ?ß -> ~c"ss"
      c when c >= ?a and c <= ?z -> [c]
      _ -> ~c""
    end
  end
end

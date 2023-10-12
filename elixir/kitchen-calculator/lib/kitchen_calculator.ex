defmodule KitchenCalculator do
  def get_volume({_, volume}), do: volume

  def to_milliliter({unit, volume}), do: {:milliliter, volume * ratio(unit)}

  def from_milliliter({_, volume}, unit), do: {unit, volume / ratio(unit)}

  def convert(volume_pair, unit) do
    volume_pair |> to_milliliter() |> from_milliliter(unit)
  end

  defp ratio(:milliliter), do: 1
  defp ratio(:cup), do: 240
  defp ratio(:fluid_ounce), do: 30
  defp ratio(:teaspoon), do: 5
  defp ratio(:tablespoon), do: 15
end

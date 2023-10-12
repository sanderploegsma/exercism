defmodule KitchenCalculator do
  def get_volume({_, volume}), do: volume

  def to_milliliter({unit, volume}), do: {:milliliter, volume * ratio(unit)}

  def from_milliliter({_, volume}, unit), do: {unit, volume / ratio(unit)}

  def convert({from_unit, volume}, to_unit) do
    {to_unit, volume * ratio(from_unit) / ratio(to_unit)}
  end

  defp ratio(:milliliter), do: 1
  defp ratio(:cup), do: 240
  defp ratio(:fluid_ounce), do: 30
  defp ratio(:teaspoon), do: 5
  defp ratio(:tablespoon), do: 15
end

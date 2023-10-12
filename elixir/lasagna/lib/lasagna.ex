defmodule Lasagna do
  def expected_minutes_in_oven(), do: 40

  def remaining_minutes_in_oven(elapsed) do
    expected_minutes_in_oven() - elapsed
  end

  def preparation_time_in_minutes(num_layers) do
    2 * num_layers
  end

  def total_time_in_minutes(num_layers, elapsed) do
    preparation_time_in_minutes(num_layers) + elapsed
  end

  def alarm(), do: "Ding!"
end

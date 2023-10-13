defmodule TakeANumber do
  @initial_state 0

  def start() do
    spawn(&loop/0)
  end

  defp loop(state \\ @initial_state) do
    receive do
      {:report_state, sender} -> send(sender, state) |> loop
      {:take_a_number, sender} -> send(sender, state + 1) |> loop
      :stop -> :ok
      _ -> loop(state)
    end
  end
end

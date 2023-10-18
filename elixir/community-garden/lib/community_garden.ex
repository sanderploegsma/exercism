# Use the Plot struct as it is provided
defmodule Plot do
  @enforce_keys [:plot_id, :registered_to]
  defstruct [:plot_id, :registered_to]
end

defmodule CommunityGarden do
  def start(opts \\ []) do
    Agent.start(fn -> {[], 1} end, opts)
  end

  def list_registrations(pid) do
    Agent.get(pid, fn {plots, _} -> plots end)
  end

  def register(pid, register_to) do
    Agent.get_and_update(pid, fn {plots, next_id} ->
      new_plot = %Plot{plot_id: next_id, registered_to: register_to}
      {new_plot, {[new_plot | plots], next_id + 1}}
    end)
  end

  def release(pid, plot_id) do
    Agent.update(pid, fn {plots, next_id} ->
      {plots |> Enum.reject(&(&1.plot_id == plot_id)), next_id}
    end)
  end

  def get_registration(pid, plot_id) do
    list_registrations(pid)
    |> Enum.find({:not_found, "plot is unregistered"}, &(&1.plot_id == plot_id))
  end
end

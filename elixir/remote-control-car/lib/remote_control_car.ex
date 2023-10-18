defmodule RemoteControlCar do
  @enforce_keys [:nickname]
  defstruct [:nickname, battery_percentage: 100, distance_driven_in_meters: 0]

  @default_nickname "none"

  def new(nickname \\ @default_nickname) do
    %RemoteControlCar{nickname: nickname}
  end

  def display_distance(%RemoteControlCar{distance_driven_in_meters: d}), do: "#{d} meters"

  def display_battery(%RemoteControlCar{battery_percentage: 0}), do: "Battery empty"
  def display_battery(%RemoteControlCar{battery_percentage: p}), do: "Battery at #{p}%"

  def drive(%RemoteControlCar{battery_percentage: 0} = remote_car), do: remote_car

  def drive(%RemoteControlCar{battery_percentage: p, distance_driven_in_meters: d} = remote_car) do
    %{remote_car | battery_percentage: p - 1, distance_driven_in_meters: d + 20}
  end
end

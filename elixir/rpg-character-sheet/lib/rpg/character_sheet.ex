defmodule RPG.CharacterSheet do
  def welcome() do
    IO.puts("Welcome! Let's fill out your character sheet together.")
  end

  def ask_name() do
    IO.gets("What is your character's name?\n")
    |> String.trim()
  end

  def ask_class() do
    IO.gets("What is your character's class?\n")
    |> String.trim()
  end

  def ask_level() do
    IO.gets("What is your character's level?\n")
    |> String.trim()
    |> String.to_integer()
  end

  def run() do
    welcome()

    %{}
    |> Map.put_new(:name, ask_name())
    |> Map.put_new(:class, ask_class())
    |> Map.put_new(:level, ask_level())
    |> IO.inspect(label: "Your character")
  end
end

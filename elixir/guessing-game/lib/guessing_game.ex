defmodule GuessingGame do
  def compare(secret_number, secret_number), do: "Correct"
  def compare(_, guess \\ :no_guess) when not is_integer(guess), do: "Make a guess"
  def compare(secret_number, guess) when abs(guess - secret_number) == 1, do: "So close"
  def compare(secret_number, guess) when guess > secret_number, do: "Too high"
  def compare(secret_number, guess) when guess < secret_number, do: "Too low"
end

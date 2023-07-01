module Raindrops
  def self.convert(number_of_drops)
    result = ""

    result += "Pling" if number_of_drops % 3 == 0
    result += "Plang" if number_of_drops % 5 == 0
    result += "Plong" if number_of_drops % 7 == 0

    result == "" ? number_of_drops.to_s : result
  end
end

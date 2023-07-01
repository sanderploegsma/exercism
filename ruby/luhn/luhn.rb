module Luhn
  def self.valid?(number)
    number = number.gsub(/\s/, "")
    
    return false if number.size <= 1
    return false if number[/\D/]

    number
      .chars
      .reverse
      .each_with_index
      .map { |d, i| i.odd? ? d.to_i * 2 : d.to_i }
      .map { |d| d > 9 ? d - 9 : d }
      .sum % 10 == 0
  end
end

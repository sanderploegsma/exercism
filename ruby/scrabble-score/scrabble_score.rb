class Scrabble
  LETTER_VALUES = {
    "AEIOULNRST" => 1,
    "DG" => 2,
    "BCMP" => 3,
    "FHVWY" => 4,
    "K" => 5,
    "JX" => 8,
    "QZ" => 10,
  }

  def initialize(word)
    @letters = word.upcase.chars
  end

  def score
    @letters.sum { |letter|
      LETTER_VALUES.find { |k,_| k.include? letter }[1]
    }
  end
end

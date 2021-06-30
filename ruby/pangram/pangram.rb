class Pangram
  ALPHABET = ('a'..'z').to_a.freeze

  def self.pangram?(input)
    (ALPHABET - input.downcase.chars).empty?
  end
end

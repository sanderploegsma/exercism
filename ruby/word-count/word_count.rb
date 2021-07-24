class Phrase
  attr_reader :word_count

  def initialize(phrase)
    @word_count = phrase.downcase.scan(/\b[\w']+\b/).tally
  end
end

class Phrase
  attr_reader :word_count

  def initialize(phrase)
    @word_count = phrase.downcase.scan(/\w+'\w+|\w+/).tally
  end
end

class Acronym
  def self.abbreviate(phrase)
    phrase.scan(/\b[a-zA-Z]/).join('').upcase
  end
end

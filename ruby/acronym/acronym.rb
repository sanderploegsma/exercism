class Acronym
    def self.abbreviate(phrase)
        phrase.split(/[\s\-,]/).map { |word| word[0] }.join('').upcase
    end
end

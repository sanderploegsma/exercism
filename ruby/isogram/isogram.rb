module Isogram
  def self.isogram?(phrase)
    letters = phrase.gsub(/[\-\s]/, "").downcase.chars.sort
    letters.each_cons(2).all? { |l,r| l != r }
  end
end

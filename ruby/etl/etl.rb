class ETL
  def self.transform(scores)
    scores
      .to_a
      .flat_map { |(score, letters)| letters.map { |l| [l.downcase, score] } }
      .to_h
  end
end

class Hamming
  def self.compute(first, second)
    raise ArgumentError, 'Strands are not of equal length' if
      first.length != second.length

    first.chars.zip(second.chars).count { |(a, b)| a != b }
  end
end

class Nucleotide
  attr_reader :histogram

  NUCLEOTIDES = %w[A C G T].freeze

  def self.from_dna(dna)
    raise ArgumentError, 'Invalid DNA' unless
      dna.chars.all? { |n| NUCLEOTIDES.include?(n) }

    histogram = NUCLEOTIDES.to_h { |n| [n, dna.count(n)] }
    Nucleotide.new(histogram)
  end

  def count(nucleotide)
    histogram[nucleotide]
  end

  private

  def initialize(histogram)
    @histogram = histogram
  end
end

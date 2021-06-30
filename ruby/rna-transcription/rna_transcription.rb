class Complement
  MAPPING = { 'C' => 'G', 'G' => 'C', 'T' => 'A', 'A' => 'U' }.freeze

  def self.of_dna(nucleotides)
    nucleotides.chars.map { |n| MAPPING.fetch(n, '') }.join('')
  end
end

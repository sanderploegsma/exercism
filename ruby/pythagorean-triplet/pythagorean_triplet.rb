class Triplet
  attr_reader :sum, :product

  def initialize(a, b, c)
    @sum = a + b + c
    @product = a * b * c
    @is_pythagorean = a < b && b < c && a**2 + b**2 == c**2
  end

  def pythagorean?
    @is_pythagorean
  end

  def self.where(max_factor:, min_factor: 0, sum: nil)
    (min_factor..max_factor).to_a.permutation(3)
                            .map { |(a, b, c)| Triplet.new(a, b, c) }
                            .select(&:pythagorean?)
                            .select { |t| sum.nil? || t.sum == sum }
  end
end

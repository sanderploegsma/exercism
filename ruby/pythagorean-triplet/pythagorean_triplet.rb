# frozen_string_literal: true

class PythagoreanTriplet
  def self.triplets_with_sum(sum)
    triplets = []

    (0...(sum / 3)).each do |a|
      (0...(sum / 2)).each do |b|
        c = sum - b - a
        triplets << [a, b, c] if a < b && a**2 + b**2 == c**2
      end
    end

    triplets
  end
end

class Grains
  SQUARE_COUNT = 64

  def self.square(square)
    raise ArgumentError, 'Invalid square' if
      square < 1 || square > SQUARE_COUNT

    1 << (square - 1)
  end

  def self.total
    (1..SQUARE_COUNT).sum { |i| Grains.square(i) }
  end
end

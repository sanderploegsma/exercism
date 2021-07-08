class Triangle
  def initialize(sides)
    @unique_sides = sides.uniq
    @valid_triangle =
      sides.all?(&:positive?) &&
      sides.permutation(3).all? { |(a, b, c)| a + b >= c }
  end

  def equilateral?
    @valid_triangle && @unique_sides.length == 1
  end

  def isosceles?
    @valid_triangle && @unique_sides.length <= 2
  end

  def scalene?
    @valid_triangle && @unique_sides.length == 3
  end
end

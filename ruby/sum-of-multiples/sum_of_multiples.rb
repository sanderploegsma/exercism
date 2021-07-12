class SumOfMultiples
  def initialize(*numbers)
    @numbers = numbers
  end

  def to(limit)
    (1..limit - 1).select { |i| multiple?(i) }.sum
  end

  private

  def multiple?(number)
    @numbers.any? { |n| (number % n).zero? }
  end
end

class Series
  def initialize(digits)
    @digits = digits
  end

  def slices(series_length)
    raise ArgumentError, 'Invalid length' if
      series_length < 1 || series_length > @digits.length

    @digits.each_char.each_cons(series_length).map(&:join)
  end
end

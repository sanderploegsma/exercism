class Series
  def initialize(digits)
    @digits = digits
  end

  def slices(series_length)
    raise ArgumentError, 'Invalid length' if
      series_length < 1 || series_length > @digits.length

    end_index = @digits.length - series_length
    (0..end_index).map { |i| @digits[i, series_length] }
  end
end

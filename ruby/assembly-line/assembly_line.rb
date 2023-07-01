class AssemblyLine
  BASE_CARS_PER_HOUR = 221

  def initialize(speed)
    @speed = speed
  end

  def success_rate
    if @speed == 10
      return 0.77
    elsif @speed == 9
      return 0.8
    elsif @speed >= 5
      return 0.9
    else
      return 1.0
    end
  end

  def production_rate_per_hour
    BASE_CARS_PER_HOUR * @speed * self.success_rate
  end

  def working_items_per_minute
    (self.production_rate_per_hour / 60).to_i
  end
end

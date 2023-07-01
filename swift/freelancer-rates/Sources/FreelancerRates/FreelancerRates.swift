let hoursPerDay = 8.0
let billableDaysPerMonth = 22.0

func discountedRateFrom(rate: Double, withDiscount discount: Double) -> Double {
  return rate * (1.0 - discount / 100.0)
}

func dailyRateFrom(hourlyRate: Int) -> Double {
  return Double(hourlyRate) * hoursPerDay
}

func monthlyRateFrom(hourlyRate: Int, withDiscount discount: Double) -> Double {
  let dailyRate = dailyRateFrom(hourlyRate: hourlyRate)
  let monthlyRate = dailyRate * billableDaysPerMonth
  return discountedRateFrom(rate: monthlyRate, withDiscount: discount).rounded()
}

func workdaysIn(budget: Double, hourlyRate: Int, withDiscount discount: Double) -> Double {
  let monthlyRate = monthlyRateFrom(hourlyRate: hourlyRate, withDiscount: discount)
  let dailyRate = monthlyRate / billableDaysPerMonth
  let workdays = budget / dailyRate
  return workdays.rounded(.down)
}

let contractLengthInMonths = 5 * 12

func canIBuy(vehicle: String, price: Double, monthlyBudget: Double) -> String {
  let monthlyPayment = price / Double(contractLengthInMonths)

  switch monthlyBudget - monthlyPayment {
    case let x where abs(x) <= 10:
      return "I'll have to be frugal if I want a \(vehicle)"
    case let x where x < 0:
      return "Darn! No \(vehicle) for me" 
    default:
      return "Yes! I'm getting a \(vehicle)"
  }
}

func licenseType(numberOfWheels wheels: Int) -> String {
  switch wheels {
    case 2, 3:
      return "You will need a motorcycle license for your vehicle"
    case 4, 6:
      return "You will need an automobile license for your vehicle"
    case 18:
      return "You will need a commercial trucking license for your vehicle"
    default:
      return "We do not issue licenses for those types of vehicles"
  }
}

func calculateResellPrice(originalPrice: Int, yearsOld: Int) -> Int {
  let resellPercentage = calculateResellPercentage(yearsOld: yearsOld)
  let resellPrice = Double(originalPrice) * resellPercentage
  return Int(resellPrice)
}

private func calculateResellPercentage(yearsOld: Int) -> Double {
  if yearsOld >= 10 {
    return 0.5
  }

  if yearsOld >= 3 {
    return 0.7
  }

  return 0.8
}

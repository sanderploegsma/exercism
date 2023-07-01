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

func registrationFee(msrp: Int, yearsOld: Int) -> Int {
  guard yearsOld < 10 else {
    return 25
  }

  let baseCost = max(Double(msrp), 25_000.0)
  let fee = (baseCost - baseCost * Double(yearsOld) * 0.1) / 100.0
  return Int(fee)
}

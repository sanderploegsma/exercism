func timeToPrepare(drinks: [String]) -> Double {
  let preparationTimes = [
    "beer": 0.5,
    "soda": 0.5,
    "water": 0.5,
    "shot": 1,
    "mixed drink": 1.5,
    "fancy drink": 2.5,
    "frozen drink": 3
  ]

  return drinks.map { preparationTimes[$0]! }.reduce(0, +)
}

func makeWedges(needed: Int, limes: [String]) -> Int {
  let wedgesPerLime = ["small": 6, "medium": 8, "large": 10]
  var wedges = 0
  var lime = 0
  while wedges < needed && lime < limes.count {
    wedges += wedgesPerLime[limes[lime]]!
    lime += 1
  }
  return lime
}

func finishShift(minutesLeft: Int, remainingOrders: [[String]]) -> [[String]] {
  var minutes = Double(minutesLeft)
  var orders = remainingOrders
  while minutes > 0 && !orders.isEmpty {
    minutes -= timeToPrepare(drinks: orders.removeFirst())
  }
  return orders
}

func orderTracker(orders: [(drink: String, time: String)]) -> (
  beer: (first: String, last: String, total: Int)?, soda: (first: String, last: String, total: Int)?
) {
  var trackers: [String : (first: String, last: String, total: Int)] = [:]
  for (drink, time) in orders {
    if let (first, last, total) = trackers[drink] {
      trackers[drink] = (min(first, time), max(last, time), total + 1)
    } else {
      trackers[drink] = (time, time, 1)
    }
  }
  return (trackers["beer"], trackers["soda"])
}

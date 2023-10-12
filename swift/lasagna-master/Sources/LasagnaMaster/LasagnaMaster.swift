func remainingMinutesInOven(elapsedMinutes: Int, expectedMinutesInOven: Int = 40) -> Int {
  return expectedMinutesInOven - elapsedMinutes
}

func preparationTimeInMinutes(layers: String...) -> Int {
  return layers.count * 2
}

func quantities(layers: String...) -> (noodles: Int, sauce: Double) {
  var noodles = 0
  var sauce = 0.0

  for layer in layers {
    if layer == "noodles" {       
      noodles += 3
    }

    if layer == "sauce" {
      sauce += 0.2
    }
  }

  return (noodles, sauce)
}

func toOz(_ x: inout (noodles: Int, sauce: Double)) {
  x.sauce = 33.814 * x.sauce
}

func redWine(layers: String...) -> Bool {
  func countLayers(_ layer: String) -> Int { layers.filter { $0 == layer }.count }

  return countLayers("mozzarella") + countLayers("ricotta") + countLayers("béchamel") <= countLayers("meat") + countLayers("sauce")
}

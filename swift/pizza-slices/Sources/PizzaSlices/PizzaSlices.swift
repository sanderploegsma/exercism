func sliceSize(diameter: Double?, slices: Int?) -> Double? {
  switch (diameter, slices) {
    case let (d?, n?) where d >= 0.0 && n > 0:
      let r = d / 2.0
      return (Double.pi * r * r) / Double(n)
    default:
      return nil
  }
}

func biggestSlice(
  diameterA: String, slicesA: String,
  diameterB: String, slicesB: String
) -> String {
  let sliceSizeA = sliceSize(diameter: Double(diameterA), slices: Int(slicesA))
  let sliceSizeB = sliceSize(diameter: Double(diameterB), slices: Int(slicesB))
  
  switch (sliceSizeA, sliceSizeB) {
    case let (a?, b?) where a > b:
      return "Slice A is bigger"
    case (.some(_), nil):
      return "Slice A is bigger"
    case let (a?, b?) where b > a:
      return "Slice B is bigger"
    case (nil, .some(_)):
      return "Slice B is bigger"
    default:
      return "Neither slice is bigger"
  }
}

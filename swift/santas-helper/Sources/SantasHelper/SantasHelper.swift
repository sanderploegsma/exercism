import Foundation

func cartesianToPolar(_ cart: (x: Double, y: Double)) -> (r: Double, phi: Double) {
  let (x, y) = cart

  return (r: (x * x + y * y).squareRoot(), phi: atan2(y, x))
}

func combineRecords(
  production: (toy: String, id: Int, productLead: String),
  gifts: (Int, [String])
) -> (id: Int, toy: String, productLead: String, recipients: [String]) {
  let (toy, id, productLead) = production
  let (_, recipients) = gifts
  return (id: id, toy: toy, productLead: productLead, recipients: recipients)
}

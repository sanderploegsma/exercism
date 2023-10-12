import Foundation

private let spacesAndHyphens = Set(" -")

func isIsogram(_ string: String) -> Bool {
  var characters = string.lowercased()
  characters.removeAll(where: spacesAndHyphens.contains)
  return characters.allSatisfy({ characters.firstIndex(of: $0) == characters.lastIndex(of: $0) })
}

enum Command: Int, CaseIterable {
  case wink = 1
  case doubleBlink = 2
  case closeYourEyes = 4
  case jump = 8
  case reverse = 16
}

func commands(number: Int) -> [String] {
  Command.allCases
    .sorted(by: { $0.rawValue <= $1.rawValue })
    .filter { number & $0.rawValue == $0.rawValue }
    .reduce(into: [String]()) { commands, command in
      switch command {
      case .wink:
        commands.append("wink")
      case .doubleBlink:
        commands.append("double blink")
      case .closeYourEyes:
        commands.append("close your eyes")
      case .jump:
        commands.append("jump")
      case .reverse:
        commands.reverse()
      }
    }
}

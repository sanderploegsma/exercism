import Foundation

extension String {
  fileprivate var isQuestion: Bool {
    self.hasSuffix("?")
  }

  fileprivate var isYelled: Bool {
    self.contains { $0.isUppercase } && self.rangeOfCharacter(from: .lowercaseLetters) == nil
  }
}

class Bob {
  static func response(_ message: String) -> String {
    let trimmed = message.trimmingCharacters(in: .whitespacesAndNewlines)

    if trimmed.isQuestion && trimmed.isYelled {
      return "Calm down, I know what I'm doing!"
    }

    if trimmed.isQuestion {
      return "Sure."
    }

    if trimmed.isYelled {
      return "Whoa, chill out!"
    }

    if trimmed.isEmpty {
      return "Fine. Be that way!"
    }

    return "Whatever."
  }
}

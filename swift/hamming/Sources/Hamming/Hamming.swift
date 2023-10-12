enum HammingError: Error {
  case strandLengthNotEqual
}

func compute(_ dnaSequence: String, against otherSequence: String) throws -> Int? {
  guard dnaSequence.count == otherSequence.count else {
    throw HammingError.strandLengthNotEqual
  }

  return zip(dnaSequence, otherSequence).filter { $0 != $1 }.count
}

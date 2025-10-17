import std/sequtils

proc distance*(a, b: string): int =
  if a.len != b.len:
    raise newException(ValueError, "strands not of equal length")

  zip(a, b).countIt(it[0] != it[1])

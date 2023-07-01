func generateCombination(forRoom room: Int, usingFunction f: (Int) -> Int) -> (Int, Int, Int) {
  let a = f(room)
  let b = f(a)
  let c = f(b)
  return (a, b, c)
}

func protectSecret(_ secret: String, withPassword password: String) -> (String) -> String {
  return { passwordAttempt in
    if passwordAttempt == password {
      return secret
    }

    return "Sorry. No hidden secrets here."
  }
}

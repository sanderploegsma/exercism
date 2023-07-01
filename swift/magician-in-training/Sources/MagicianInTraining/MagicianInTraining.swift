func getCard(at index: Int, from stack: [Int]) -> Int {
  return stack[index]
}

func setCard(at index: Int, in stack: [Int], to newCard: Int) -> [Int] {
  var result = stack
  
  if index >= 0 && index < result.count {
    result[index] = newCard
  }

  return result
}

func insert(_ newCard: Int, atTopOf stack: [Int]) -> [Int] {
  return stack + [newCard]
}

func removeCard(at index: Int, from stack: [Int]) -> [Int] {
  var result = stack
  
  if index >= 0 && index < result.count {
    result.remove(at: index)
  }

  return result
}

func removeTopCard(_ stack: [Int]) -> [Int] {
  var result = stack
  
  if !result.isEmpty {
    result.removeLast()
  }
  
  return result
}

func insert(_ newCard: Int, atBottomOf stack: [Int]) -> [Int] {
  return [newCard] + stack
}

func removeBottomCard(_ stack: [Int]) -> [Int] {
  var result = stack
  
  if !result.isEmpty {
    result.remove(at: 0)
  }

  return result
}

func checkSizeOfStack(_ stack: [Int], _ size: Int) -> Bool {
  return stack.count == size
}

func evenCardCount(_ stack: [Int]) -> Int {
  return stack.filter { $0 % 2 == 0 }.count
}

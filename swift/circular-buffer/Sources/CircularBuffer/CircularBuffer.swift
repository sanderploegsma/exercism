enum CircularBufferError: Error {
  case bufferEmpty
  case bufferFull
}

struct CircularBuffer<T> {
  private var items: [T]
  private let capacity: Int

  init(capacity: Int) {
    self.items = []
    self.capacity = capacity
  }

  mutating func read() throws -> T {
    guard !items.isEmpty else {
      throw CircularBufferError.bufferEmpty
    }

    return items.removeFirst()
  }

  mutating func write(_ item: T) throws {
    guard items.count < capacity else {
      throw CircularBufferError.bufferFull
    }

    items.append(item)
  }

  mutating func overwrite(_ item: T) {
    if items.count == capacity {
      _ = items.removeFirst()
    }

    items.append(item)
  }

  mutating func clear() {
    items.removeAll()
  }
}

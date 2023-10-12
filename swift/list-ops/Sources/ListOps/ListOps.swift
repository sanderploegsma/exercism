class ListOps {
  static func foldLeft<T, U>(_ list: [T], accumulated: U, combine: (U, T) -> U) -> U {
    var result = accumulated
    for item in list {
      result = combine(result, item)
    }
    return result
  }

  static func foldRight<T, U>(_ list: [T], accumulated: U, combine: (T, U) -> U) -> U {
    var result = accumulated
    for index in stride(from: list.endIndex - 1, to: list.startIndex - 1, by: -1) {
      result = combine(list[index], result)
    }
    return result
  }

  static func append<T>(_ first: [T], _ second: [T]) -> [T] {
    var result = [T]()
    for item in first {
      result.append(item)
    }
    for item in second {
      result.append(item)
    }
    return result
  }

  static func concat<T>(_ lists: [T]...) -> [T] {
    foldLeft(lists, accumulated: [], combine: { append($0, $1) })
  }

  static func filter<T>(_ list: [T], _ predicate: (T) -> Bool) -> [T] {
    foldLeft(list, accumulated: [], combine: { predicate($1) ? append($0, [$1]) : $0 })
  }

  static func length<T>(_ list: [T]) -> Int {
    foldLeft(list, accumulated: 0, combine: { acc, _ in acc + 1 })
  }

  static func map<T, U>(_ list: [T], f: (T) -> U) -> [U] {
    foldLeft(list, accumulated: [], combine: { append($0, [f($1)]) })
  }

  static func reverse<T>(_ list: [T]) -> [T] {
    foldRight(list, accumulated: [], combine: { append($1, [$0]) })
  }
}

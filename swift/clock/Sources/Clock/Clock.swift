import Foundation

struct Clock: Equatable {
  private let max = 24 * 60
  private let minutes: Int

  init(hours: Int, minutes: Int) {
    let totalMinutes = hours * 60 + minutes
    let mod = totalMinutes % max
    self.minutes = mod >= 0 ? mod : mod + max
  }

  func add(minutes: Int) -> Clock {
    Clock(hours: 0, minutes: self.minutes + minutes)
  }

  func subtract(minutes: Int) -> Clock {
    Clock(hours: 0, minutes: self.minutes - minutes)
  }

  var description: String {
    let h = self.minutes / 60
    let m = self.minutes % 60
    return String(format: "%02d:%02d", h, m)
  }
}

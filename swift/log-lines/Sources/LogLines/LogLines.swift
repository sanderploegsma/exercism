import Foundation

enum LogLevel: Int {
  case trace = 0
  case debug = 1
  case info = 4
  case warning = 5
  case error = 6
  case fatal = 7
  case unknown = 42

  init(_ message: String) {
    let prefixes: [String: LogLevel] = [
      "[TRC]": .trace,
      "[DBG]": .debug,
      "[INF]": .info,
      "[WRN]": .warning,
      "[ERR]": .error,
      "[FTL]": .fatal,
    ]

    let prefix = String(message.prefix(5))
    self = prefixes[prefix] ?? .unknown
  }

  func shortFormat(message: String) -> String {
    "\(self.rawValue):\(message)"
  }
}

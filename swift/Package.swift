// swift-tools-version:5.8

import Foundation
import PackageDescription

extension String {
  var pascalCased: String {
    let items = self.components(separatedBy: "-")
    return items.reduce("", { $0 + $1.capitalized })
  }
}

func contentsOfDirectory(at url: URL, includingPropertiesForKeys properties: [URLResourceKey]?)
  -> [URL]
{
  return
    (try? FileManager.default.contentsOfDirectory(at: url, includingPropertiesForKeys: properties))
    ?? []
}

let directory = URL(fileURLWithPath: FileManager.default.currentDirectoryPath)
let exercises = contentsOfDirectory(at: directory, includingPropertiesForKeys: [.isDirectoryKey])
  .filter { dir in
    contentsOfDirectory(at: dir, includingPropertiesForKeys: [.isRegularFileKey]).contains {
      $0.lastPathComponent == "Package.swift"
    }
  }
  .map { $0.lastPathComponent }

let targets: [Target] = exercises.flatMap {
  return [
    .target(name: $0.pascalCased, path: "\($0)/Sources"),
    .testTarget(
      name: "\($0.pascalCased)Tests",
      dependencies: [
        .target(name: $0.pascalCased)
      ],
      path: "\($0)/Tests"
    ),
  ]
}

let package = Package(
  name: "swift",
  products: [
    .library(
      name: "swift",
      targets: targets.filter { $0.type == .regular }.map { $0.name }
    )
  ],
  targets: targets
)

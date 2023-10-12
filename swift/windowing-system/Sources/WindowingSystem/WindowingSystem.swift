struct Position {
  var x: Int = 0
  var y: Int = 0

  mutating func moveTo(newX: Int, newY: Int) {
    self.x = newX
    self.y = newY
  }
}

struct Size {
  var width: Int = 80
  var height: Int = 60

  mutating func resize(newWidth: Int, newHeight: Int) {
    self.width = newWidth
    self.height = newHeight
  }
}

class Window {
  var title: String = "New Window"
  let screenSize = Size(width: 800, height: 600)
  var size: Size = Size()
  var position: Position = Position()
  var contents: String? = nil

  func resize(to newSize: Size) {
    let newWidth = min(max(1, newSize.width), screenSize.width - position.x)
    let newHeight = min(max(1, newSize.height), screenSize.height - position.y)
    size.resize(newWidth: newWidth, newHeight: newHeight)
  }

  func move(to newPosition: Position) {
    let newX = min(max(0, newPosition.x), screenSize.width - size.width)
    let newY = min(max(0, newPosition.y), screenSize.height - size.height)
    position.moveTo(newX: newX, newY: newY)
  }

  func update(title newTitle: String) {
    title = newTitle
  }

  func update(text newContents: String?) {
    contents = newContents
  }

  func display() -> String {
    let displayPosition = "Position: (\(position.x), \(position.y))"
    let displaySize = "Size: (\(size.width) x \(size.height))"
    let displayContents = contents ?? "[This window intentionally left blank]"
    return """
      \(title)
      \(displayPosition), \(displaySize)
      \(displayContents)

      """
  }
}

let mainWindow: Window = {
  let window = Window()
  window.resize(to: Size(width: 400, height: 300))
  window.move(to: Position(x: 100, y: 100))
  window.update(title: "Main Window")
  window.update(text: "This is the main window")
  return window
}()

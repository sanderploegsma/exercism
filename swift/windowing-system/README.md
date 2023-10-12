# Windowing System

Welcome to Windowing System on Exercism's Swift Track.
If you need help running the tests or submitting your code, check out `HELP.md`.
If you get stuck on the exercise, check out `HINTS.md`, but try and solve it without using those first :)

## Introduction

## Structs And Classes

Structs and classes are two of the primary building blocks of Swift programming. They are both means of grouping together related data and functions into self-contained units of functionality. And when you define a struct or class, you are defining a new type to be used within Swift, just as you used the types you've already worked with, like `Int` and `String`.

There are many similarities between structs and classes in Swift. Among other similarities, both are able to store values in _properties_ and provide functionality through the use of _methods_.

They each provide some additional functionality, which is out of scope for this exercise.

### Defining structs and classes

Both structs and classes are defined in roughly the same way. They start with the appropriate keyword followed by the type name that is being defined, then the body of the struct/class follows, placed between curly braces.

The body may consist of stored properties, which are defined and behave just like regular constants or variables.

```swift
struct CharacterStats {
  var health = 0.0
  var speed = 0
  var strength = 0
}

class GameCharacter {
  var stats = CharacterStats()
  var characterClass: String?
  var name: String?
  var active = false
  let id = makeRandomID()
}
```

### Instances

As noted above, defining a struct or class is just defining a new _type_. It is just the blueprint for what the values of that type will look like, but it does not actually create any values of that type for you to work with.

In order to create an _instance_ of that type, you need to write the name of the type followed by a pair of parentheses.

```swift
let someStats = CharacterStats()
let someCharacter = GameCharacter()
```

This will create values of these types, where the properties are populated with the default values supplied in the definition. Note that in optional cases like GameCharacter's `name` property, unless a value is provided, the property will default to nil, just like defining regular optional types where a value is not immediately provided.

With structs, Swift automatically provides something called a _memberwise initializer_, where values for the structs properties may be provided inside the parentheses which will override the default values in the definition.

```swift
let differentStats = CharacterStats(health: 100.0, speed: 6, strength: 18)
```

### Accessing properties

Struct and class properties can be accessed using _dot notation_ where the name of the value is followed by a dot (`.`) and the name of the property. If a property of a struct or class has properties of its own, this dot notation can be used to access these nested properties as well.

This notation can be used both to retrieve the property's value and, where allowed, to change it.

```swift
someStats.health
// => 0
someCharacter.name
// => nil

someStats.health = 87.3
someStats.health
// => 87.3
someCharacter.name = "Luther"
someCharacter.name
// => "Luther"

someCharacter.id  = "new id"
// Error: Cannot assign to property: 'id' is a 'let' constant
```

### Methods

Like properties, which store data in your structs and classes, you may also define _methods_ which store functions in your struct or class.

Methods are defined in the same way as a regular function, only inside the body of the struct or class. Note that if a function changes the value of a property in a struct, it must be preceded by the `mutating` keyword. Additionally, if a property can be changed by a method, that property must be defined using `var` rather than `let`, just like regular variables.

```swift
struct CharacterStats {
  var health = 0.0
  var speed = 0
  var strength = 0

  mutating func takeHit(_ damage: Double) {
    health = max(0.0, health - damage)
  }
  func canLift(_ weight: Int) -> Bool {
    weight < strength * 100
  }
}

class GameCharacter {
  var stats = CharacterStats()
  var characterClass: String?
  var name: String?
  var active = false
  let id: String = makeRandomID()

  func takesDamage(_ damage: Double) {
    stats.takeHit(damage)
    if stats.health <= 0 {
      active = false
    }
  }
  func sayName() -> String {
    return "My name is \(name ?? "no one"), my class is \(characterClass ?? "undetermined")"
  }
  func lift(_ weight: Int) -> String {
    if stats.canLift(weight) {
      return "No problem!"
    } else {
      return "Ooof! No way."
    }
  }
}
```

These methods can be called using dot notation, just like properties.

```swift
var myChar = GameCharacter()
myChar.stats = CharacterStats(health: 72.8, speed: 19, strength: 6)
myChar.active = true

myChar.lift(750)
// => "Ooof! No way."
myChar.takesDamage(80)
myChar.active
// => false
```

### Self

Instances of structs and classes each have an implicit value named `self` which refers to the instance itself. There are multiple uses for `self`, but it is most commonly used to disambiguate the names of properties and methods of the struct/class when there may be some confusion.

```swift
struct MySelf {
  var x = 0

  mutating func move(x: Int) {
    // here if we just say x = x it is unclear if we mean
    // the property x or the method parameter x, so we use
    // self for clarity
    self.x = x
  }
}
```

## Instructions

In this exercise, you will be simulating a windowing based computer system. You will create some windows that can be moved and resized and display their contents. The following image is representative of the values you will be working with below.

```
                  <--------------------- screenSize.width --------------------->

       ^          ╔════════════════════════════════════════════════════════════╗
       |          ║                                                            ║
       |          ║          position.x,_                                      ║
       |          ║          position.y  \                                     ║
       |          ║                       \<----- size.width ----->            ║
       |          ║                 ^      *──────────────────────┐            ║
       |          ║                 |      │        title         │            ║
       |          ║                 |      ├──────────────────────┤            ║
screenSize.height ║                 |      │                      │            ║
       |          ║            size.height │                      │            ║
       |          ║                 |      │       contents       │            ║
       |          ║                 |      │                      │            ║
       |          ║                 |      │                      │            ║
       |          ║                 v      └──────────────────────┘            ║
       |          ║                                                            ║
       |          ║                                                            ║
       v          ╚════════════════════════════════════════════════════════════╝
```

## 1. Define a Size struct

Define a struct named `Size` with two `Int` properties, `width` and `height` that store the window's current width and height, respectively. The initial width and height should be 80 and 60, respectively. Include a method `resize(newWidth:newHeight:)` that takes new width and height parameters and changes the properties to reflect the new size.

```swift
let size1080x764 = Size(width: 1080, height: 764)
// => Size
var size1200x800 = size1080x764
// => Size
size1200x800.resize(newWidth: 1200, newHeight: 800)
size1200x800.height
// => 800
```

## 2. Define a Position struct

Define a struct named `Position` with two `Int` properties, `x` and `y` that store the current horizontal and vertical position, respectively, of the window's upper left corner. The initial values of x and y should each be 0. The position (0, 0) is the upper left corner of the screen with `x` values getting larger as you move right and `y` values getting larger as you move down.

Include a method `moveTo(newX:newY:)` that takes new x and y parameters and changes the properties to reflect the new position.

```swift
var point = Position(x: 10, y: 20)
// => Position
point.moveTo(newX: 100, newY: -100)
point.y
// => -100
```

## 3. Define a Window class

Define a window class with the following properties:

- `title` : `String`, Initial value is "New Window"
- `screenSize` : `Size`, constant value with `width` = 800 and `height` = 600
- `size` : `Size`, initial value is the default value of the `Size` struct
- `position` : `Position`, initial value is the default value of the `Position` struct
- `contents` : `String?`, initial value is `nil`

## 4. Add a method to resize windows

- `resize(to:)` : `(Size) -> ()` - This method takes a `Size` struct as input and attempts to resize the window to the specified size. However, the new size cannot exceed certain bounds. - The minimum allowed height or width is 1. Requested heights or widths less than 1 will be clipped to 1. - The maximum height and width depends on the current position of the window, the edges of the window cannot move past the edges of the screen. Values larger than these bounds will be clipped to the largest size they can take. E.g. if the window's position is at `x` = 400, `y` = 300 and a resize to `height` = 400, `width` = 300 is requested, then the window would be resized to `height` = 300, `width` = 300 as the screen is not large enough in the `y` direction to fully accommodate the request.

## 5. Add a method to move windows

- `move(to:)` : `(Position) -> ()` - This is similar to `resize(to:)`, however, this method adjusts the _position_ of the window to the requested value, rather than the size. As with `resize` the new position cannot exceed certain limits. - The smallest position is 0 for both `x` and `y`. - The maximum position in either direction depends on the current size of the window; the edges cannot move past the edges of the screen. Values larger than these bounds will be clipped to the largest size they can take. E.g. if the window's size is at `x` = 250, `y` = 100 and a move to `x` = 600, `y` = 200 is requested, then the window would be moved to `x` = 550, `y` = 200 as the screen is not large enough in the `x` direction to fully accommodate the request.

## 6. Add methods to update the window text and display window information

- `update(title:)` : `(String) -> ()` - This method sets the `title` property to the value of the string that was passed in.
- `update(text:)` : `(String?) -> ()` - This method sets the `contents` property to the value of the optional string that was passed in.
- `display()` : `() -> String` - This method returns a string describing the current state of the window. For example, if the window has the `title` "My First Window" with position: x = 10, y = 100; size: width = 200, height = 150; and contents: "I 😍 my window", it should return the string: `"My First Window\nPosition: (10, 100), Size: (200 x 150)\nI 😍 my window\n"` - If `contents` is nil, the last line should read "[This window intentionally left blank]"

## 7. Create a new Window

Create an instances of the Window class and modify it via their methods as follows:

- The window should be given the title "Main Window", with a width of 400, a height of 300 and positioned at x = 100, y = 100. Its contents should be "This is the main window". Assign this instance to the name `mainWindow`.

## Source

### Created by

- @wneumann
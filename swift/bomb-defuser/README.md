# Double-Null0111: Closures Are Forever

Welcome to Double-Null0111: Closures Are Forever on Exercism's Swift Track.
If you need help running the tests or submitting your code, check out `HELP.md`.
If you get stuck on the exercise, check out `HINTS.md`, but try and solve it without using those first :)

## Introduction

Closures in Swift are self-contained blocks of code that can be passed parameters to trigger their computation and return values. Closures also capture values from their environment and use them in their computations. As they are self contained, they may be passed around in a program like other values or assigned to constants and variables.

Closures may sound a lot like Swift functions; they do, and for good reason. Functions in swift are just special cases of closures which are required to have a name and are defined using a slightly different syntax.

While functions in Swift are technically closures, when people refer to "closures" in Swift, they are referring to [closure expressions][closure-expressions]. Closure expressions are written as a parameter list followed by a return type and the keyword `in` followed by the body of the closure, all contained in a pair of curly braces:

```swift
{ (a: Double, b: Double) -> Double in
  return a + b / 2.0
}
```

This defines a closure expression of type `(Double, Double) -> Double`, and it can be executed in a similar manner to a function of this type, by applying it to parameters of the appropriate type:

```swift
{ (a: Double, b: Double) -> Double in
  return a + b / 2.0
}(10.0, 15.0)
// => 12.5
```

As it's not very convenient to write out the full closure expression every time one wants to execute it, closures can be assigned to names, like any other value in Swift. They can then be called by applying the name to the parameters:

```swift
let mean = { (a: Double, b: Double) -> Double in
  a + b / 2.0
}

mean(13.0, 100.0)
// => 56.5
```

As seen above, closures, like regular functions, may omit the `return` keyword if the body of the closure is a single expression.

Most often, closures are used with higher-order functions, either passed in as parameters or returned as results:

```swift
[11, 75, 3, 99, 53].contains(where: { (x: Int) -> Bool in x > 100 })
// => false

["apple", "ball", "carrot"].sorted(by: { (s1: String, s2: String) -> Bool in s1.count < s2.count })
// => ["ball", "apple", "carrot"]

func makeAdder(base: Int) -> (Int) -> Int {
  { (x: Int) -> Int in base + x }
}
```

## Instructions

Hello again, Agent Double-Null0111.

The forces of UMBRA are acting up again, and it is up to you to foil their latest scheme. Our intel branch informs us that those Minions are planning to set off a stink-bomb at the Governor's ball.

Since the minions are so clumsy, they often accidentally arm the stink-bombs in their labs and offices. And because they keep forgetting how to disarm their stink-bombs, they have implemented a system generate the disarming instructions that list the order the wires must be cut from the bomb's ID number.

Your job is to write the code that will allow you to disarm the stink-bomb at the ball before it goes off.

## 1. Write a closure to flip two wires

There are three differently colored wires on each stink-bomb. Write a closure that takes a `(String, String, String)` tuple and returns the tuple with the order of the first two elements flipped. Assign this closure to the name `flip`.

```swift
flip(("red", "yellow", "blue"))
// => ("yellow", "red", "blue")
```

## 2. Write a closure to rotate the wires

Write a closure that takes a `(String, String, String)` tuple and returns the tuple with the order of the wires rotated to the left. Assign this closure to the name `rotate`.

```swift
rotate(("red", "yellow", "blue"))
// => ("yellow", "blue", "red")
```

## 3. Implement a wire shuffle generator

In order to figure out the order in which to cut the stink-bomb wires, you will need to implement a function that generates the proper shuffling function based on the ID number of the stink-bomb.

Implement the function:

```swift
makeShuffle(
  flipper: @escaping ((String, String, String)) -> (String, String, String),
  rotator: @escaping ((String, String, String)) -> (String, String, String)
) -> (UInt8, (String, String, String)) -> (String, String, String)
```

which takes as input a closure that flips two wires and a closure that rotates the three wires and returns a closure. This returned closure takes the ID number of the stink-bomb and the order of the three wires, and then computes the order the wires need to be cut. This is computed as follows:

For each bit in the ID number, starting with the rightmost bit, you will apply the `flipper` closure to the wires tuple if the bit is a 0 and you will apply the `rotator` closure if it is a 1 giving the new state of the wires.
After the appropriate closures have been applied for all eight bits of the ID, the final state of the wires is the order they need to be cut in.

```swift
let shuffler = makeShuffle(flipper: flip, rotator: rotate)
// => (UInt8, (String, String, String)) -> (String, String, String)
shuffler(155, ("red", "yellow", "blue"))
// => ("red", "blue", "yellow")
```

## Source

### Created by

- @wneumann
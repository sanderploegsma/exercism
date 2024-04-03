import gleam/order.{type Order}
import gleam/float
import gleam/list

pub type City {
  City(name: String, temperature: Temperature)
}

pub type Temperature {
  Celsius(Float)
  Fahrenheit(Float)
}

pub fn fahrenheit_to_celsius(f: Float) -> Float {
  { f -. 32.0 } /. 1.8
}

pub fn compare_temperature(left: Temperature, right: Temperature) -> Order {
  let to_celsius = fn(temperature: Temperature) -> Float {
    case temperature {
      Celsius(c) -> c
      Fahrenheit(f) -> fahrenheit_to_celsius(f)
    }
  }

  float.compare(to_celsius(left), to_celsius(right))
}

pub fn sort_cities_by_temperature(cities: List(City)) -> List(City) {
  list.sort(cities, by: fn(left, right) {
    compare_temperature(left.temperature, right.temperature)
  })
}

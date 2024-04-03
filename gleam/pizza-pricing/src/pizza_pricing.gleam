import gleam/list

pub type Pizza {
  Margherita
  Caprese
  Formaggio
  ExtraSauce(Pizza)
  ExtraToppings(Pizza)
}

pub fn pizza_price(pizza: Pizza) -> Int {
  calculate_pizza_price(pizza, 0)
}

fn calculate_pizza_price(pizza: Pizza, price: Int) -> Int {
  case pizza {
    Margherita -> price + 7
    Caprese -> price + 9
    Formaggio -> price + 10
    ExtraSauce(pizza) -> calculate_pizza_price(pizza, price + 1)
    ExtraToppings(pizza) -> calculate_pizza_price(pizza, price + 2)
  }
}

pub fn order_price(order: List(Pizza)) -> Int {
  let additional_fee = case list.length(order) {
    1 -> 3
    2 -> 2
    _ -> 0
  }

  calculate_order_price(order, additional_fee)
}

fn calculate_order_price(order: List(Pizza), price: Int) -> Int {
  case order {
    [] -> price
    [pizza, ..tail] -> calculate_order_price(tail, price + pizza_price(pizza))
  }
}

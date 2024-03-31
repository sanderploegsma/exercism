pub fn expected_minutes_in_oven() -> Int {
  40
}

pub fn remaining_minutes_in_oven(elapsed: Int) -> Int {
  expected_minutes_in_oven() - elapsed
}

pub fn preparation_time_in_minutes(layers: Int) -> Int {
  layers * 2
}

pub fn total_time_in_minutes(layers: Int, elapsed: Int) -> Int {
  preparation_time_in_minutes(layers) + elapsed
}

pub fn alarm() -> String {
  "Ding!"
}

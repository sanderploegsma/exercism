import gleam/result

pub fn with_retry(experiment: fn() -> Result(t, e)) -> Result(t, e) {
  case experiment() {
    Ok(t) -> Ok(t)
    Error(_) -> experiment()
  }
}

pub fn record_timing(
  time_logger: fn() -> Nil,
  experiment: fn() -> Result(t, e),
) -> Result(t, e) {
  time_logger()
  let t = experiment()
  time_logger()
  t
}

pub fn run_experiment(
  name: String,
  setup: fn() -> Result(t, e),
  action: fn(t) -> Result(u, e),
  record: fn(t, u) -> Result(v, e),
) -> Result(#(String, v), e) {
  use a <- result.try(setup())
  use b <- result.try(action(a))
  use c <- result.try(record(a, b))
  Ok(#(name, c))
}

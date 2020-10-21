fn is_factor(n: u32, f: u32, on_match: String) -> Option<String> {
    if n % f == 0 {
        Some(on_match)
    } else {
        None
    }
}

fn check_factors(n: u32) -> Option<String> {
    [
        is_factor(n, 3, String::from("Pling")),
        is_factor(n, 5, String::from("Plang")),
        is_factor(n, 7, String::from("Plong")),
    ]
    .iter()
    .flat_map(|x| x)
    .fold(None, |acc, cur| match acc {
        Some(x) => Some(x + cur),
        None => Some(cur.to_string()),
    })
}

pub fn raindrops(n: u32) -> String {
    match check_factors(n) {
        Some(x) => x,
        None => n.to_string(),
    }
}

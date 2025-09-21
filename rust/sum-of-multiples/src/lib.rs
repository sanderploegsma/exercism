pub fn sum_of_multiples(limit: u32, factors: &[u32]) -> u32 {
    (1..limit)
        .filter(|x| factors.into_iter().any(|&f| f > 0 && x % f == 0))
        .sum()
}

pub fn factors(mut n: u64) -> Vec<u64> {
    let mut div = 2;
    let mut factors = vec![];

    while n > 1 {
        while n % div == 0 {
            factors.push(div);
            n /= div;
        }

        div += 1;
    }

    factors
}

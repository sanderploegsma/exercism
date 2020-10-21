struct Primes {
    found: Vec<u32>,
    i: u32,
}

impl Iterator for Primes {
    type Item = u32;

    fn next(&mut self) -> Option<u32> {
        while !self.found.iter().all(|&p| self.i % p != 0) {
            self.i += 1;
        }

        let new_prime = self.i;
        self.found.push(new_prime);
        self.i += 1;

        Some(new_prime)
    }
}

fn primes() -> Primes {
    Primes {
        found: vec![],
        i: 2,
    }
}

pub fn nth(n: u32) -> u32 {
    use std::convert::TryFrom;
    primes().nth(usize::try_from(n).unwrap()).unwrap()
}

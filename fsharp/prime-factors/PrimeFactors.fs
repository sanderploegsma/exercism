module PrimeFactors

let factors number =
    let rec find n p primes =
        match n with
        | 1L -> primes
        | n when n % (int64 p) = 0L -> find (n / (int64 p)) p (primes @ [ p ])
        | n -> find n (p + 1) primes

    find number 2 []
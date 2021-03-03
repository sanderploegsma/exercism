package sieve

// Sieve calculates all primes up to the given limit.
func Sieve(limit int) []int {
	candidates := make([]bool, limit+1)

	primes := 0
	result := make([]int, limit/2)

	for n := 2; n <= limit; n++ {
		if candidates[n] {
			continue
		}

		result[primes] = n
		primes++

		for m := n; m <= limit; m += n {
			candidates[m] = true
		}
	}

	return result[:primes]
}

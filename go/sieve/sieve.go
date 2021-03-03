package sieve

// Sieve calculates all primes up to the given limit.
func Sieve(limit int) []int {
	if limit < 2 {
		return []int{}
	}

	candidates := make([]int, limit-1)
	for n := 2; n <= limit; n++ {
		candidates[n-2] = n
	}

	primes := []int{}
	for len(candidates) > 0 {
		p := candidates[0]
		primes = append(primes, p)
		candidates = filterMultiplesOf(p, candidates)
	}

	return primes
}

func filterMultiplesOf(a int, numbers []int) []int {
	result := make([]int, len(numbers))
	filtered := 0

	for _, b := range numbers {
		if b%a != 0 {
			result[filtered] = b
			filtered++
		}
	}

	return result[:filtered]
}

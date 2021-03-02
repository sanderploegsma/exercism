package diffsquares

// SquareOfSum calculates the square of the sum of natural numbers until the given limit.
func SquareOfSum(limit int) int {
	sum := 0
	for i := 1; i <= limit; i++ {
		sum = sum + i
	}
	return sum * sum
}

// SumOfSquares calculates the sum of the squares of natural numbers until the given limit.
func SumOfSquares(limit int) int {
	sum := 0
	for i := 1; i <= limit; i++ {
		sum = sum + i*i
	}
	return sum
}

// Difference calculates the difference between the square of the sum and the sum of the squares
// of natural numbers until the given limit.
func Difference(limit int) int {
	return SquareOfSum(limit) - SumOfSquares(limit)
}

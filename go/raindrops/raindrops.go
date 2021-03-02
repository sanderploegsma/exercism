package raindrops

import (
	"fmt"
	"strings"
)

// Convert creates raindrop sounds based on the input number.
// If the number is evenly divisible by 3, it adds "Pling"
// If the number is evenly divisible by 5, it adds "Plang"
// If the number is evenly divisible by 7, it adds "Plong"
// Otherwise, it returns the number as string
func Convert(n int) string {
	var sb strings.Builder

	if isDivisbleBy(n, 3) {
		sb.WriteString("Pling")
	}

	if isDivisbleBy(n, 5) {
		sb.WriteString("Plang")
	}

	if isDivisbleBy(n, 7) {
		sb.WriteString("Plong")
	}

	if result := sb.String(); result != "" {
		return result
	}

	return fmt.Sprint(n)
}

func isDivisbleBy(a, b int) bool {
	return a%b == 0
}

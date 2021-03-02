package hamming

import "errors"

// Distance calculates the hamming distance between two DNA strands
func Distance(a, b string) (int, error) {
	if len(a) != len(b) {
		return 0, errors.New("strands should be of equal length")
	}

	dist := 0
	for i := range a {
		if a[i] != b[i] {
			dist = dist + 1
		}
	}

	return dist, nil
}

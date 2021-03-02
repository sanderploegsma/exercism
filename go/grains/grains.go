package grains

import "errors"

const numberOfSquares = 64

// Square calculates the number of grains on the given square.
func Square(n int) (uint64, error) {
	if n < 1 || n > numberOfSquares {
		return 0, errors.New("n is out of bounds")
	}

	return 1 << (n - 1), nil
}

// Total calculates the total number of grains on a chess board.
func Total() uint64 {
	var grains uint64 = 0
	for i := 1; i <= numberOfSquares; i++ {
		n, _ := Square(i)
		grains += n
	}
	return grains
}

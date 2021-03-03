package luhn

import (
	"strconv"
	"strings"
)

// Valid checks if the given credit card number is valid per the Luhn formula.
func Valid(creditCardNumber string) bool {
	digits := strings.ReplaceAll(creditCardNumber, " ", "")

	if len(digits) < 2 {
		return false
	}

	checksum, ok := calculateChecksum(digits)
	return ok && checksum%10 == 0
}

func calculateChecksum(digits string) (int, bool) {
	checksum := 0
	for i := len(digits) - 1; i >= 0; i-- {
		digit, err := strconv.Atoi(string(digits[i]))
		if err != nil {
			return 0, false
		}

		position := len(digits) - 1 - i
		if position%2 == 1 {
			checksum += double(digit)
		} else {
			checksum += digit
		}
	}
	return checksum, true
}

func double(digit int) int {
	result := digit * 2
	if result > 9 {
		return result - 9
	}
	return result
}

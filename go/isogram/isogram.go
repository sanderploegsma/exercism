package isogram

import (
	"strings"
	"unicode"
)

// IsIsogram checks whether the given input is a word or sequence without repeating letters.
func IsIsogram(input string) bool {
	letters := make(map[rune]bool)

	for _, c := range strings.ToLower(input) {
		if !unicode.IsLetter(c) {
			continue
		}

		if seen, ok := letters[c]; ok && seen {
			return false
		}

		letters[c] = true
	}

	return true
}

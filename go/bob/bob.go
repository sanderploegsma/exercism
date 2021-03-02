package bob

import (
	"strings"
	"unicode"
)

// Hey generates Bob's response on the given remark.
func Hey(remark string) string {
	normalized := strings.TrimSpace(remark)

	if normalized == "" {
		return "Fine. Be that way!"
	}

	isQuestion := strings.HasSuffix(normalized, "?")
	isAllCaps := strings.ToUpper(normalized) == normalized && strings.IndexFunc(normalized, unicode.IsLetter) >= 0

	if isQuestion && isAllCaps {
		return "Calm down, I know what I'm doing!"
	}

	if isQuestion {
		return "Sure."
	}

	if isAllCaps {
		return "Whoa, chill out!"
	}

	return "Whatever."
}

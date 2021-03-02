package accumulate

// Accumulate applies the given function to the given list of items and returns the result.
func Accumulate(items []string, f func(string) string) []string {
	result := make([]string, 0)
	for _, item := range items {
		result = append(result, f(item))
	}
	return result
}

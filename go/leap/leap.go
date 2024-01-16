// Package leap contains the solution for the Leap exercise on Exercism.
package leap

// IsLeapYear indicates whether the given year is a leap year.
func IsLeapYear(year int) bool {
	return year % 400 == 0 || year % 100 != 0 && year % 4 == 0
}

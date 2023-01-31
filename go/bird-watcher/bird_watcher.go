package birdwatcher

// TotalBirdCount return the total bird count by summing
// the individual day's counts.
func TotalBirdCount(birdsPerDay []int) int {
	sum := 0
	for _, birds := range birdsPerDay {
		sum += birds
	}
	return sum
}

// BirdsInWeek returns the total bird count by summing
// only the items belonging to the given week.
func BirdsInWeek(birdsPerDay []int, week int) int {
	weekStart := (week - 1) * 7
	weekEnd := weekStart + 7
	return TotalBirdCount(birdsPerDay[weekStart:weekEnd])
}

// FixBirdCountLog returns the bird counts after correcting
// the bird counts for alternate days.
func FixBirdCountLog(birdsPerDay []int) []int {
	for i, birds := range birdsPerDay {
		if i%2 == 0 {
			birdsPerDay[i] = birds + 1
		} else {
			birdsPerDay[i] = birds
		}
	}
	return birdsPerDay
}

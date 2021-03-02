// Package gigasecond contains functions that allow working with gigaseconds
package gigasecond

import "time"

// AddGigasecond returns the given time, with a gigasecond added
func AddGigasecond(t time.Time) time.Time {
	return t.Add(1_000_000_000 * time.Second)
}

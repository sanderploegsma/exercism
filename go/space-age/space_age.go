package space

// Planet is a planet in our solar system.
type Planet string

const secondsInEarthYear = 31557600.0

var orbitalPeriods = map[Planet]float64{
	"Mercury": 0.2408467,
	"Venus":   0.61519726,
	"Earth":   1.0,
	"Mars":    1.8808158,
	"Jupiter": 11.862615,
	"Saturn":  29.447498,
	"Uranus":  84.016846,
	"Neptune": 164.79132,
}

// Age calculates the age on the given planet based on the given age in seconds.
func Age(seconds float64, planet Planet) float64 {
	earthYears := seconds / secondsInEarthYear

	if period, ok := orbitalPeriods[planet]; ok {
		return earthYears / period
	}

	return 0
}

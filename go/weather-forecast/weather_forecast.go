// Package weather contains functionality to forecast the current weather condition of various cities in Goblinocus.
package weather

// CurrentCondition contains the latest condition used in the forecast.
var CurrentCondition string

// CurrentLocation contains the latest location used in the forecast.
var CurrentLocation string

// Forecast creates a forecast for the given city and condition.
func Forecast(city, condition string) string {
	CurrentLocation, CurrentCondition = city, condition
	return CurrentLocation + " - current weather condition: " + CurrentCondition
}

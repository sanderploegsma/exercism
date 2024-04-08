package elon

import (
	"fmt"
	"math"
)



func (c *Car) Drive() {
	if c.battery < c.batteryDrain {
		return
	}

	c.battery -= c.batteryDrain
	c.distance += c.speed
}

func (c *Car) DisplayDistance() string {
	return fmt.Sprintf("Driven %d meters", c.distance)
}

func (c *Car) DisplayBattery() string {
	return fmt.Sprintf("Battery at %d%%", c.battery)
}

func (c *Car) CanFinish(trackDistance int) bool {
	drivesNeeded := int(math.Ceil(float64(trackDistance) / float64(c.speed)))
	drivesLeft := int(float64(c.battery) / float64(c.batteryDrain))
	return drivesLeft >= drivesNeeded
}

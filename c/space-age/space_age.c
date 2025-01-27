#include "space_age.h"

const float seconds_per_earth_year = 31557600.0f;

static float orbital_periods[] = {
    0.2408467f,
    0.61519726f,
    1.0f,
    1.8808158f,
    11.862615f,
    29.447498f,
    84.016846f,
    164.79132f};

float age(planet_t planet, int64_t seconds)
{
    if (planet < MERCURY || planet > NEPTUNE)
    {
        return INVALID_PLANET;
    }

    return ((float)seconds) / seconds_per_earth_year / orbital_periods[planet];
}

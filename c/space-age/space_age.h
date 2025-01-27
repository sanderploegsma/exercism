#ifndef SPACE_AGE_H
#define SPACE_AGE_H

#include <stdint.h>

#define INVALID_PLANET -1

typedef enum planet
{
   MERCURY,
   VENUS,
   EARTH,
   MARS,
   JUPITER,
   SATURN,
   URANUS,
   NEPTUNE,
} planet_t;

float age(planet_t planet, int64_t seconds);

#endif

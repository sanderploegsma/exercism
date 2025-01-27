#include "grains.h"
#include "limits.h"

const uint8_t num_squares = 64;

uint64_t square(uint8_t index)
{
    if (index < 1 || index > num_squares)
    {
        return 0;
    }

    return 1ull << (index - 1);
}

uint64_t total(void)
{
    return ULLONG_MAX;
}

#include "hamming.h"
#include <string.h>

int compute(const char *lhs, const char *rhs)
{
    size_t len = strlen(lhs);
    if (strlen(rhs) != len)
    {
        return INVALID_INPUT;
    }

    int d = 0;
    for (size_t i = 0; i < len; i++)
    {
        if (lhs[i] != rhs[i])
        {
            d++;
        }
    }

    return d;
}

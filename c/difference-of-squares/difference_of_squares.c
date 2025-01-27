#include "difference_of_squares.h"

unsigned int sum_of_squares(unsigned int number)
{
    unsigned int sum = 0;
    for (unsigned int n = 1; n <= number; n++)
    {
        sum += n * n;
    }
    return sum;
}

unsigned int square_of_sum(unsigned int number)
{
    unsigned int sum = 0;
    for (unsigned int n = 1; n <= number; n++)
    {
        sum += n;
    }
    return sum * sum;
}

unsigned int difference_of_squares(unsigned int number)
{
    return square_of_sum(number) - sum_of_squares(number);
}

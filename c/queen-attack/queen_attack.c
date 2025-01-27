#include "queen_attack.h"
#include <stdbool.h>
#include <stdlib.h>

const uint8_t board_size = 8;

static bool is_valid(position_t queen)
{
    return queen.row < board_size && queen.column < board_size;
}

static bool is_same_row(position_t queen_1, position_t queen_2)
{
    return queen_1.row == queen_2.row;
}

static bool is_same_column(position_t queen_1, position_t queen_2)
{
    return queen_1.column == queen_2.column;
}

static bool is_same_diagonal(position_t queen_1, position_t queen_2)
{
    return abs(queen_2.row - queen_1.row) ==
           abs(queen_2.column - queen_1.column);
}

attack_status_t can_attack(position_t queen_1, position_t queen_2)
{
    if (!is_valid(queen_1) ||
        !is_valid(queen_2) ||
        (is_same_row(queen_1, queen_2) && is_same_column(queen_1, queen_2)))
    {
        return INVALID_POSITION;
    }

    if (is_same_row(queen_1, queen_2) ||
        is_same_column(queen_1, queen_2) ||
        is_same_diagonal(queen_1, queen_2))
    {
        return CAN_ATTACK;
    }

    return CAN_NOT_ATTACK;
}

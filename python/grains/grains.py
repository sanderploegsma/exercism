NUM_SQUARES = 64

def square(number):
    if number < 1 or number > NUM_SQUARES:
        raise ValueError(f"square must be between 1 and {NUM_SQUARES}")

    return 2 ** (number - 1)


def total():
    return sum([square(n) for n in range(1, NUM_SQUARES + 1)])

from random import choice, seed
from string import ascii_uppercase, digits


def generate():
    seed()
    return "".join(
        [
            choice(ascii_uppercase),
            choice(ascii_uppercase),
            choice(digits),
            choice(digits),
            choice(digits),
        ]
    )


class Robot:
    def __init__(self):
        self.name = generate()

    def reset(self):
        self.name = generate()
"""Solution to Ellen's Alien Game exercise."""
from typing import Tuple

class Alien:
    """Create an Alien object with location x_coordinate and y_coordinate."""

    total_aliens_created = 0

    def __init__(self, x_coordinate: int, y_coordinate: int) -> None:
        self.x_coordinate = x_coordinate
        self.y_coordinate = y_coordinate
        self.health = 3
        Alien.total_aliens_created += 1

    def hit(self) -> None:
        self.health -= 1

    def is_alive(self) -> bool:
        return self.health > 0

    def teleport(self, new_x_coordinate: int, new_y_coordinate: int) -> None:
        self.x_coordinate = new_x_coordinate
        self.y_coordinate = new_y_coordinate

    def collision_detection(self, other):
        pass

def new_aliens_collection(start_positions: list[Tuple[int, int]]) -> None:
    return [Alien(p[0], p[1]) for p in start_positions]

#[derive(PartialEq, Eq, Debug)]
pub enum Direction {
    North,
    East,
    South,
    West,
}

impl Direction {
    fn clockwise(self) -> Direction {
        match self {
            Self::North => Self::East,
            Self::East => Self::South,
            Self::South => Self::West,
            Self::West => Self::North,
        }
    }

    fn counter_clockwise(self) -> Direction {
        match self {
            Self::North => Self::West,
            Self::West => Self::South,
            Self::South => Self::East,
            Self::East => Self::North,
        }
    }
}

pub struct Robot {
    x: i32,
    y: i32,
    direction: Direction,
}

impl Robot {
    pub fn new(x: i32, y: i32, d: Direction) -> Self {
        Robot { x, y, direction: d }
    }

    #[must_use]
    pub fn turn_right(self) -> Self {
        Self {
            direction: self.direction.clockwise(),
            ..self
        }
    }

    #[must_use]
    pub fn turn_left(self) -> Self {
        Self {
            direction: self.direction.counter_clockwise(),
            ..self
        }
    }

    #[must_use]
    pub fn advance(self) -> Self {
        match self.direction {
            Direction::North => Self {
                y: self.y + 1,
                ..self
            },
            Direction::East => Self {
                x: self.x + 1,
                ..self
            },
            Direction::South => Self {
                y: self.y - 1,
                ..self
            },
            Direction::West => Self {
                x: self.x - 1,
                ..self
            },
        }
    }

    #[must_use]
    pub fn instructions(self, instructions: &str) -> Self {
        instructions.chars().fold(self, |robot, c| match c {
            'A' => robot.advance(),
            'L' => robot.turn_left(),
            'R' => robot.turn_right(),
            _ => robot,
        })
    }

    pub fn position(&self) -> (i32, i32) {
        (self.x, self.y)
    }

    pub fn direction(&self) -> &Direction {
        &self.direction
    }
}

use std::collections::HashSet;

pub struct Triangle {
    unique_sides: HashSet<u64>,
}

impl Triangle {
    pub fn build(sides: [u64; 3]) -> Option<Triangle> {
        match sides {
            [0, _, _] | [_, 0, _] | [_, _, 0] => None,
            [a, b, c] if a + b < c || b + c < a || c + a < b => None,
            _ => Some(Triangle {
                unique_sides: HashSet::from(sides),
            }),
        }
    }

    pub fn is_equilateral(&self) -> bool {
        self.unique_sides.len() == 1
    }

    pub fn is_scalene(&self) -> bool {
        self.unique_sides.len() == 3
    }

    pub fn is_isosceles(&self) -> bool {
        self.unique_sides.len() < 3
    }
}

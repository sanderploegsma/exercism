#[derive(Debug, PartialEq, Eq)]
pub enum Comparison {
    Equal,
    Sublist,
    Superlist,
    Unequal,
}

pub fn sublist(first_list: &[i32], second_list: &[i32]) -> Comparison {
    match (first_list, second_list) {
        (x, y) if x == y => Comparison::Equal,
        (x, y) if contains(x, y) => Comparison::Superlist,
        (x, y) if contains(y, x) => Comparison::Sublist,
        _ => Comparison::Unequal,
    }
}

fn contains(parent: &[i32], child: &[i32]) -> bool {
    match (parent, child) {
        (_, []) => true,
        (p, c) if c.len() >= p.len() => false,
        (p, c) => p.windows(c.len()).any(|l| l == c),
    }
}

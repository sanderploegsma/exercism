/// Check a Luhn checksum.
pub fn is_valid(code: &str) -> bool {
    match digits(code) {
        Some(digits) => digits.len() > 1 && checksum(digits) % 10 == 0,
        None => false,
    }
}

fn digits(code: &str) -> Option<Vec<u32>> {
    code.chars()
        .filter(|c| !c.is_whitespace())
        .map(|c| c.to_digit(10))
        .collect()
}

fn checksum(digits: Vec<u32>) -> u32 {
    let mut sum = 0;

    for (i, &x) in digits.iter().rev().enumerate() {
        let mut digit = x;
        if i % 2 == 1 {
            digit *= 2;
            if digit > 9 {
                digit -= 9;
            }
        }
        sum += digit;
    }

    sum
}

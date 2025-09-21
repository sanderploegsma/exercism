pub fn is_armstrong_number(num: u32) -> bool {
    let num_s = num.to_string();
    let num_digits = num_s.len() as u32;
    num_s.chars()
        .map(|d| d.to_digit(10).unwrap().pow(num_digits))
        .sum::<u32>() == num
}

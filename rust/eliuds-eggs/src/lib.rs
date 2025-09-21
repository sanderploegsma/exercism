pub fn egg_count(display_value: u32) -> usize {
    let mut count = 0;
    let mut value = display_value;

    while value > 0 {
        count += value & 1;
        value >>= 1;
    }

    count as usize
}

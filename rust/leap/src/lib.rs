pub fn is_leap_year(year: u64) -> bool {
    return year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)
}

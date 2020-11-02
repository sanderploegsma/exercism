use std::fmt;

const MINUTES_IN_HOUR: i32 = 60;
const HOURS_IN_DAY: i32 = 24;

#[derive(Eq, PartialEq, Debug)]
pub struct Clock {
    minutes: i32,
}

fn modulus(a: i32, b: i32) -> i32 {
    ((a % b) + b) % b
}

impl Clock {
    pub fn new(hours: i32, minutes: i32) -> Self {
        let total_minutes = hours * MINUTES_IN_HOUR + minutes;
        Clock { minutes: modulus(total_minutes, HOURS_IN_DAY * MINUTES_IN_HOUR) }
    }

    pub fn add_minutes(&self, minutes: i32) -> Self {
        Clock { minutes: modulus(self.minutes + minutes, HOURS_IN_DAY * MINUTES_IN_HOUR) }
    }
}

impl fmt::Display for Clock {
    fn fmt(&self, f: &mut fmt::Formatter<'_>) -> fmt::Result {
        let hours = (self.minutes / MINUTES_IN_HOUR) % HOURS_IN_DAY;
        let minutes = self.minutes % MINUTES_IN_HOUR;
        write!(f, "{:0>2}:{:0>2}", hours, minutes)
    }
}

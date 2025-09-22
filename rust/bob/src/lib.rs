fn is_yelled(message: &str) -> bool {
    message.chars().any(|c| c.is_alphabetic()) && message.to_uppercase() == message
}

pub fn reply(message: &str) -> &str {
    match message.trim() {
        "" => "Fine. Be that way!",
        m if m.ends_with('?') && is_yelled(m) => "Calm down, I know what I'm doing!",
        m if is_yelled(m) => "Whoa, chill out!",
        m if m.ends_with('?') => "Sure.",
        _ => "Whatever.",
    }
}

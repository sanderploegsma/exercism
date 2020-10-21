fn how_many_bottles(n: u32) -> String {
    match n {
        0 => String::from("no more bottles"),
        1 => String::from("1 bottle"),
        2..=u32::MAX => n.to_string() + " bottles",
    }
}

pub fn verse(n: u32) -> String {
    match n {
        0 => format!("No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n"),
        1 => format!("1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n"),
        _ => format!("{} of beer on the wall, {} of beer.\nTake one down and pass it around, {} of beer on the wall.\n", how_many_bottles(n), how_many_bottles(n), how_many_bottles(n - 1)),
    }
}

pub fn sing(start: u32, end: u32) -> String {
    let mut res = vec![];

    for i in end..=start {
        res.push(verse(i))
    }

    res.reverse();
    res.join("\n")
}

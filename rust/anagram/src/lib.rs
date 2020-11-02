use std::collections::HashSet;
use itertools::Itertools;

fn is_anagram(a: String, b: String) -> bool {
    a != b && a.chars().sorted().collect::<String>() == b.chars().sorted().collect::<String>()
}

pub fn anagrams_for<'a>(word: &str, possible_anagrams: &'a [&str]) -> HashSet<&'a str> {
    possible_anagrams
        .iter()
        .copied()
        .filter(|&w| is_anagram(w.to_lowercase(), word.to_lowercase()))
        .collect()
}

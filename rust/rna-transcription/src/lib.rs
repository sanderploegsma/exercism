use std::str::FromStr;

use strum_macros::EnumString;

#[derive(Debug, PartialEq, Eq, EnumString)]
pub enum DnaNucleotide {
    A,
    C,
    G,
    T,
}

#[derive(Debug, PartialEq, Eq, EnumString)]
pub enum RnaNucleotide {
    A,
    C,
    G,
    U,
}

impl DnaNucleotide {
    fn transcribe(&self) -> RnaNucleotide {
        match self {
            DnaNucleotide::G => RnaNucleotide::C,
            DnaNucleotide::C => RnaNucleotide::G,
            DnaNucleotide::T => RnaNucleotide::A,
            DnaNucleotide::A => RnaNucleotide::U,
        }
    }
}

fn parse<T: FromStr>(s: &str) -> Result<Vec<T>, usize> {
    s.chars()
        .enumerate()
        .map(|(i, c)| c.to_string().parse::<T>().map_err(|_| i))
        .collect()
}

#[derive(Debug, PartialEq, Eq)]
pub struct Dna(Vec<DnaNucleotide>);

#[derive(Debug, PartialEq, Eq)]
pub struct Rna(Vec<RnaNucleotide>);

impl Dna {
    pub fn new(dna: &str) -> Result<Dna, usize> {
        parse(dna).map(Dna)
    }

    pub fn into_rna(self) -> Rna {
        Rna(self.0.iter().map(|n| n.transcribe()).collect())
    }
}

impl Rna {
    pub fn new(rna: &str) -> Result<Rna, usize> {
        parse(rna).map(Rna)
    }
}

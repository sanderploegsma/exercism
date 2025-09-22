use std::str::FromStr;

macro_rules! dna_rna {
    ($struct_name:ident, $enum_name:ident, $($enum_member:tt),+) => {
        #[derive(Debug, PartialEq, Eq)]
        pub enum $enum_name { $($enum_member),+ }

        impl FromStr for $enum_name {
            type Err = ();

            fn from_str(s: &str) -> Result<$enum_name, ()> {
                $(if s == stringify!($enum_member) { Ok($enum_name::$enum_member) } else)*
                { Err(()) }
            }
        }

        #[derive(Debug, PartialEq, Eq)]
        pub struct $struct_name(Vec<$enum_name>);

        impl FromIterator<$enum_name> for $struct_name {
            fn from_iter<T: IntoIterator<Item = $enum_name>>(iter: T) -> Self {
                $struct_name(iter.into_iter().collect())
            }
        }

        impl $struct_name {
            pub fn new(s: &str) -> Result<$struct_name, usize> {
                s.chars()
                    .enumerate()
                    .map(|(i, c)| c.to_string().parse::<$enum_name>().map_err(|_| i))
                    .collect()
            }
        }
    };
}

dna_rna!(Dna, DnaNucleotide, A, C, G, T);
dna_rna!(Rna, RnaNucleotide, A, C, G, U);

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

impl Dna {
    pub fn into_rna(self) -> Rna {
        Rna(self.0.iter().map(|n| n.transcribe()).collect())
    }
}

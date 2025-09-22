use self::Allergen::*;

pub struct Allergies(u32);

#[derive(Debug, PartialEq, Eq, Clone, Copy)]
pub enum Allergen {
    Eggs = 1 << 0,
    Peanuts = 1 << 1,
    Shellfish = 1 << 2,
    Strawberries = 1 << 3,
    Tomatoes = 1 << 4,
    Chocolate = 1 << 5,
    Pollen = 1 << 6,
    Cats = 1 << 7,
}

const ALLERGENS: [Allergen; 8] = [
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats,
];

impl Allergies {
    pub fn new(score: u32) -> Self {
        Allergies(score)
    }

    pub fn is_allergic_to(&self, allergen: &Allergen) -> bool {
        self.0 & *allergen as u32 > 0
    }

    pub fn allergies(&self) -> Vec<Allergen> {
        ALLERGENS
            .into_iter()
            .filter(|a| self.is_allergic_to(a))
            .collect()
    }
}

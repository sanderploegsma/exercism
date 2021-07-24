class Allergies(private val score: Int) {
    fun getList(): List<Allergen> = Allergen.values().filter { isAllergicTo(it) }

    fun isAllergicTo(allergen: Allergen) = allergen.score and score > 0
}

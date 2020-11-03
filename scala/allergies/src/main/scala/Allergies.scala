sealed trait Allergen
object Allergen {
  case object Eggs extends Allergen
  case object Peanuts extends Allergen
  case object Shellfish extends Allergen
  case object Strawberries extends Allergen
  case object Tomatoes extends Allergen
  case object Chocolate extends Allergen
  case object Pollen extends Allergen
  case object Cats extends Allergen
}

object Allergies {
  private val masks: Map[Allergen, Int] = Map(
    Allergen.Eggs -> 1,
    Allergen.Peanuts -> 2,
    Allergen.Shellfish -> 4,
    Allergen.Strawberries -> 8,
    Allergen.Tomatoes -> 16,
    Allergen.Chocolate -> 32,
    Allergen.Pollen -> 64,
    Allergen.Cats -> 128
  )

  def allergicTo(allergen: Allergen, input: Int): Boolean = (masks.getOrElse(allergen, 0) & input) > 0

  def list(input: Int): List[Allergen] = masks.keys.toList.filter {
    allergicTo(_, input)
  }
}
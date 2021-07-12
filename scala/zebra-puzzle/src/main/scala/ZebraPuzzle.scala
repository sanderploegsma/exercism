object ZebraPuzzle {
  private val colors = Seq(Red, Green, Ivory, Yellow, Blue)
  private val residents = Seq(Englishman, Spaniard, Ukrainian, Norwegian, Japanese)
  private val pets = Seq(Dog, Snails, Fox, Horse, Zebra)
  private val drinks = Seq(Coffee, Tea, Milk, OrangeJuice, Water)
  private val smokes = Seq(OldGold, Kools, Chesterfields, LuckyStrike, Parliaments)

  lazy val solve: Solution = {
    val solutions = for {
      colors <- colors.permutations
      if colors.indexOf(Green) == colors.indexOf(Ivory) + 1 // Green house is right of Ivory house
      residents <- residents.permutations
      if residents.head == Norwegian // Norwegian lives in first house
      if math.abs(residents.indexOf(Norwegian) - colors.indexOf(Blue)) == 1 // Norwegian lives next to blue house
      if residents.indexOf(Englishman) == colors.indexOf(Red) // Englishman lives in red house
      pets <- pets.permutations
      if residents.indexOf(Spaniard) == pets.indexOf(Dog) // Spaniard owns dog
      drinks <- drinks.permutations
      if drinks.indexOf(Milk) == 2 // Milk is drunk in the middle house
      if drinks.indexOf(Coffee) == colors.indexOf(Green) // Coffee is drunk in the green house
      if residents.indexOf(Ukrainian) == drinks.indexOf(Tea) // Ukranians drink tea
      smokes <- smokes.permutations
      if smokes.indexOf(Kools) == colors.indexOf(Yellow) // Kools are smoked in the yellow house
      if smokes.indexOf(LuckyStrike) == drinks.indexOf(OrangeJuice) // LuckyStrike smoker drinks orange juice
      if residents.indexOf(Japanese) == smokes.indexOf(Parliaments) // Japanese smokes parliaments
      if smokes.indexOf(OldGold) == pets.indexOf(Snails) // OldGold smoker owns snails
      if math.abs(smokes.indexOf(Kools) - pets.indexOf(Horse)) == 1 // Kools are smoked next to horse
      if math.abs(smokes.indexOf(Chesterfields) - pets.indexOf(Fox)) == 1 // Man who smokes Chesterfields lives next to man with fox
    } yield (0 until 5).map { i =>
      House(residents(i), colors(i), pets(i), drinks(i), smokes(i))
    }

    val solution = solutions.next()

    Solution(
      waterDrinker = solution.filter(_.drink == Water).head.resident,
      zebraOwner = solution.filter(_.pet == Zebra).head.resident
    )
  }

  case class Solution(waterDrinker: Resident, zebraOwner: Resident)

  case class House(resident: Resident, color: Color, pet: Pet, drink: Drink, smoke: Smoke)

  sealed trait Resident

  case object Englishman extends Resident

  case object Spaniard extends Resident

  case object Ukrainian extends Resident

  case object Norwegian extends Resident

  case object Japanese extends Resident

  sealed trait Color

  case object Red extends Color

  case object Green extends Color

  case object Ivory extends Color

  case object Yellow extends Color

  case object Blue extends Color

  sealed trait Pet

  case object Dog extends Pet

  case object Snails extends Pet

  case object Fox extends Pet

  case object Horse extends Pet

  case object Zebra extends Pet

  sealed trait Drink

  case object Coffee extends Drink

  case object Tea extends Drink

  case object Milk extends Drink

  case object OrangeJuice extends Drink

  case object Water extends Drink

  sealed trait Smoke

  case object OldGold extends Smoke

  case object Kools extends Smoke

  case object Chesterfields extends Smoke

  case object LuckyStrike extends Smoke

  case object Parliaments extends Smoke
}


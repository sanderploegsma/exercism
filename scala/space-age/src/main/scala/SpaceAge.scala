sealed trait Planet
case object Earth extends Planet
case object Mercury extends Planet
case object Venus extends Planet
case object Mars extends Planet
case object Jupiter extends Planet
case object Saturn extends Planet
case object Uranus extends Planet
case object Neptune extends Planet

object SpaceAge {
  private val earthOrbitalPeriodSeconds = 31557600D
  private val relativeOrbitalPeriods: Map[Planet, Double] = Map(
    Earth -> 1.0,
    Mercury -> 0.2408467,
    Venus -> 0.61519726,
    Mars -> 1.8808158,
    Jupiter -> 11.862615,
    Saturn -> 29.447498,
    Uranus -> 84.016846,
    Neptune -> 164.79132
  )

  private def calculateAgeOn(planet: Planet): Double => Double =
    seconds => seconds / earthOrbitalPeriodSeconds / relativeOrbitalPeriods.getOrElse(planet, 1.0)

  def onEarth(seconds: Double): Double = calculateAgeOn(Earth).apply(seconds)
  def onMercury(seconds: Double): Double = calculateAgeOn(Mercury).apply(seconds)
  def onVenus(seconds: Double): Double = calculateAgeOn(Venus).apply(seconds)
  def onMars(seconds: Double): Double = calculateAgeOn(Mars).apply(seconds)
  def onJupiter(seconds: Double): Double = calculateAgeOn(Jupiter).apply(seconds)
  def onSaturn(seconds: Double): Double = calculateAgeOn(Saturn).apply(seconds)
  def onUranus(seconds: Double): Double = calculateAgeOn(Uranus).apply(seconds)
  def onNeptune(seconds: Double): Double = calculateAgeOn(Neptune).apply(seconds)
}
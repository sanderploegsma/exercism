import java.math.BigDecimal
import java.math.RoundingMode

class SpaceAge(private val seconds: Long) {

    companion object {
        private const val EARTH_ORBITAL_PERIOD_SECONDS = 31557600.0
        private const val PRECISION = 2

        private enum class Planet(val relativeOrbitalPeriod: Double) {
            EARTH(1.0),
            MERCURY(0.2408467),
            VENUS(0.61519726),
            MARS(1.8808158),
            JUPITER(11.862615),
            SATURN(29.447498),
            URANUS(84.016846),
            NEPTUNE(164.79132);
        }
    }

    fun onEarth(): Double = Planet.EARTH.spaceAge
    fun onMercury(): Double = Planet.MERCURY.spaceAge
    fun onVenus(): Double = Planet.VENUS.spaceAge
    fun onMars(): Double = Planet.MARS.spaceAge
    fun onJupiter(): Double = Planet.JUPITER.spaceAge
    fun onSaturn(): Double = Planet.SATURN.spaceAge
    fun onUranus(): Double = Planet.URANUS.spaceAge
    fun onNeptune(): Double = Planet.NEPTUNE.spaceAge

    private val Planet.spaceAge
        get() : Double {
            val age = seconds / EARTH_ORBITAL_PERIOD_SECONDS / relativeOrbitalPeriod
            return BigDecimal(age).setScale(PRECISION, RoundingMode.HALF_UP).toDouble()
        }
}

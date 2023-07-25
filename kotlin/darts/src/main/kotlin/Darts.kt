import kotlin.math.ceil
import kotlin.math.sqrt

object Darts {

    fun score(x: Number, y: Number): Int = when (distance(x.toDouble(), y.toDouble())) {
        in 0..1 -> 10
        in 2..5 -> 5
        in 6..10 -> 1
        else -> 0
    }

    private fun distance(x: Double, y: Double): Int {
        val r = sqrt(x * x + y * y)
        return ceil(r).toInt()
    }
}

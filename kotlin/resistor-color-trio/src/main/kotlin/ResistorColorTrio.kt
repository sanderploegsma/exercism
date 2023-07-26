import kotlin.math.pow

object ResistorColorTrio {

    fun text(vararg input: Color): String {
        val (c1, c2, c3) = input.map { it.ordinal }
        val value = (c1 * 10 + c2) * 10.0.pow(c3).toInt()
        val (unit, unitValue) = Unit.values()
            .associateWith { 1_000.0.pow(it.ordinal).toInt() }
            .entries
            .sortedByDescending { it.value }
            .first { value % it.value == 0 }

        return "${value / unitValue} ${unit.name.lowercase()}"
    }
}

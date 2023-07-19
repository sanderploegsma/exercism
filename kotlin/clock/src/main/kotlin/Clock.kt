private const val MAX_MINUTES = 24 * 60

class Clock(hours: Int, minutes: Int) {

    private var minutes = (60 * hours + minutes).mod(MAX_MINUTES)

    fun subtract(minutes: Int) {
        this.minutes = (this.minutes - minutes).mod(MAX_MINUTES)
    }

    fun add(minutes: Int) {
        this.minutes = (this.minutes + minutes).mod(MAX_MINUTES)
    }

    override fun equals(other: Any?) = when (other) {
        is Clock -> other.minutes == this.minutes
        else -> false
    }

    override fun hashCode() = minutes

    override fun toString(): String {
        val displayHours = minutes / 60
        val displayMinutes = minutes % 60
        return "%02d:%02d".format(displayHours, displayMinutes)
    }
}

import java.time.LocalDate
import java.time.LocalDateTime

private const val GIGASECOND = 1e9.toLong()

class Gigasecond(time: LocalDateTime) {
    constructor(date: LocalDate) : this(date.atStartOfDay())

    val date: LocalDateTime = time.plusSeconds(GIGASECOND)
}

import MeetupSchedule.*
import java.time.DayOfWeek
import java.time.LocalDate
import java.time.Month
import java.time.Year

private val TEENTHS = (13..19)

class Meetup(month: Int, year: Int) {
    private val month = Month.of(month)
    private val year = Year.of(year)
    private val days = (1..this.month.length(this.year.isLeap))
    private val dates by lazy { days.map { LocalDate.of(year, month, it) } }

    fun day(dayOfWeek: DayOfWeek, schedule: MeetupSchedule): LocalDate {
        val candidates = dates.filter { it.dayOfWeek == dayOfWeek }

        return when (schedule) {
            FIRST, SECOND, THIRD, FOURTH -> candidates[schedule.ordinal]
            LAST -> candidates.last()
            TEENTH -> candidates.first { it.dayOfMonth in TEENTHS }
        }
    }
}

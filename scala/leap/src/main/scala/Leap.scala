object Leap {
  def leapYear(year: Int): Boolean = year % 400 == 0 || (year % 100 != 0 && year % 4 == 0)
}

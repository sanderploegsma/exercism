class Year {
  let isLeapYear: Bool

  init(calendarYear year: Int) {
    isLeapYear = year.isMultiple(of: 400) || year.isMultiple(of: 4) && !year.isMultiple(of: 100)
  }
}

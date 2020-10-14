using System;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly DateTime[] _days;

    public Meetup(int month, int year)
    {
        _days = Enumerable
            .Range(1, DateTime.DaysInMonth(year, month))
            .Select(day => new DateTime(year, month, day))
            .ToArray();
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var candidates = _days.Where(dt => dt.DayOfWeek == dayOfWeek);

        return schedule switch
        {
            Schedule.First => candidates.First(),
            Schedule.Second => candidates.Skip(1).First(),
            Schedule.Third => candidates.Skip(2).First(),
            Schedule.Fourth => candidates.Skip(3).First(),
            Schedule.Last => candidates.Last(),
            Schedule.Teenth => candidates.First(dt => dt.Day >= 13 && dt.Day <= 19),
            _ => throw new ArgumentException("Invalid schedule")
        };
    }
}
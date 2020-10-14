using System;

public static class Gigasecond
{
    const double GigasecondDuration = 1e9;

    public static DateTime Add(DateTime moment) => moment.AddSeconds(GigasecondDuration);
}
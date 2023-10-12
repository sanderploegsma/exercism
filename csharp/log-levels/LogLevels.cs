static class LogLine
{
    public static string Message(string logLine) =>
        logLine.Split(':')[1].Trim();

    public static string LogLevel(string logLine) =>
        logLine.Split(':')[0].Trim('[', ']').ToLowerInvariant();

    public static string Reformat(string logLine) =>
        $"{Message(logLine)} ({LogLevel(logLine)})";
}

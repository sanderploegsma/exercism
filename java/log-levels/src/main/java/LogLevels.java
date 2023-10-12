import java.util.regex.Pattern;

public class LogLevels {
    private static final Pattern LOG_LINE_PATTERN = Pattern.compile(
            "^\\[(?<level>[A-Z]+)]:\\s*(?<message>.*)$", Pattern.DOTALL);

    private final String level;
    private final String message;

    private LogLevels(String logLine) {
        var matcher = LOG_LINE_PATTERN.matcher(logLine);
        if (!matcher.matches()) {
            throw new IllegalArgumentException("Log line doesn't match expected pattern");
        }

        this.level = matcher.group("level").toLowerCase();
        this.message = matcher.group("message").trim();
    }

    public static String message(String logLine) {
        return new LogLevels(logLine).message;
    }

    public static String logLevel(String logLine) {
        return new LogLevels(logLine).level;
    }

    public static String reformat(String logLine) {
        var logLevels = new LogLevels(logLine);
        return String.format("%s (%s)", logLevels.message, logLevels.level);
    }
}

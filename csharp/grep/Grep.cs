using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        var options = ParseOptions(flags);
        if (files.Length > 1)
        {
            options |= Options.PrintFileNames;
        }

        var data = files
            .SelectMany(ReadFile)
            .Where(line => MatchLine(line, pattern, options))
            .OrderBy(line => line.File)
            .ThenBy(line => line.LineNumber);

        return string.Join("\n", PrintLines(data, options));
    }

    private static bool MatchLine(Line line, string pattern, Options options)
    {
        var contents = line.Contents;
        if (options.HasFlag(Options.MatchCaseInsensitive))
        {
            contents = contents.ToLower();
            pattern = pattern.ToLower();
        }

        var isMatch = options.HasFlag(Options.MatchFullLinesOnly) ? contents == pattern : contents.Contains(pattern);
        return options.HasFlag(Options.InvertMatch) ? !isMatch : isMatch;
    }

    private static IEnumerable<string> PrintLines(IEnumerable<Line> lines, Options options)
    {
        if (options.HasFlag(Options.PrintFileNamesOnly))
        {
            return lines.Select(x => x.File).Distinct();
        }

        return lines.Select(line => PrintLine(line, options));
    }

    private static string PrintLine(Line line, Options options)
    {
        var sb = new StringBuilder();
        if (options.HasFlag(Options.PrintFileNames))
        {
            sb.Append(line.File);
            sb.Append(":");
        }

        if (options.HasFlag(Options.PrintLineNumbers))
        {
            sb.Append(line.LineNumber);
            sb.Append(":");
        }

        sb.Append(line.Contents);
        return sb.ToString();
    }

    private static IEnumerable<Line> ReadFile(string file) => File.ReadLines(file)
        .Select((line, i) => new Line {File = file, Contents = line, LineNumber = i + 1});

    private static Options ParseOptions(string flags) => FlagsToOptions
        .Where(option => flags.Contains(option.Key))
        .Aggregate(Options.None, (current, option) => current | option.Value);

    private static readonly IDictionary<string, Options> FlagsToOptions = new Dictionary<string, Options>
    {
        {"-n", Options.PrintLineNumbers},
        {"-l", Options.PrintFileNamesOnly},
        {"-i", Options.MatchCaseInsensitive},
        {"-v", Options.InvertMatch},
        {"-x", Options.MatchFullLinesOnly}
    };

    [Flags]
    private enum Options
    {
        None = 1 << 0,
        PrintLineNumbers = 1 << 1,
        PrintFileNamesOnly = 1 << 2,
        PrintFileNames = 1 << 3,
        MatchCaseInsensitive = 1 << 4,
        MatchFullLinesOnly = 1 << 5,
        InvertMatch = 1 << 6,
    }

    private class Line
    {
        public string File { get; set; }
        public string Contents { get; set; }
        public int LineNumber { get; set; }
    }
}
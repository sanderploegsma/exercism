using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class Markdown
{
    private const char HeaderSymbol = '#';
    private const char ListSymbol = '*';

    public static string Parse(string markdown)
    {
        var lines = markdown.Split('\n');
        var result = new StringBuilder();

        var i = 0;
        while (i < lines.Length)
        {
            var line = lines[i];
            switch (line[0])
            {
                case HeaderSymbol:
                    var header = ParseHeader(line);
                    result.Append(header);
                    i++;
                    break;
                case ListSymbol:
                    var listItems = lines.Skip(i).TakeWhile(x => x.StartsWith(ListSymbol)).Select(ParseListItem).ToList();
                    var list = string.Concat(listItems).Wrap("ul");
                    result.Append(list);
                    i += listItems.Count;
                    break;
                default:
                    var paragraph = ParseParagraph(line);
                    result.Append(paragraph);
                    i++;
                    break;
            }
        }

        return result.ToString();
    }
    
    private static string ParseHeader(string markdown)
    {
        var level = markdown.TakeWhile(c => c == HeaderSymbol).Count();
        return ParseText(markdown.TrimStart(HeaderSymbol, ' ')).Wrap($"h{level}");
    }

    private static string ParseListItem(string markdown) => ParseText(markdown.TrimStart(ListSymbol, ' ')).Wrap("li"); 

    private static string ParseParagraph(string markdown) => ParseText(markdown).Wrap("p");
    
    private static string ParseText(string markdown) => 
        markdown
            .ReplaceDelimiter("__", "strong")
            .ReplaceDelimiter("_", "em");
    
    private static string Wrap(this string text, string tag) => $"<{tag}>{text}</{tag}>";

    private static string ReplaceDelimiter(this string markdown, string delimiter, string tag)
    {
        var pattern = $"{delimiter}(.+){delimiter}";
        var replacement = "$1".Wrap(tag);
        return Regex.Replace(markdown, pattern, replacement);
    }

}
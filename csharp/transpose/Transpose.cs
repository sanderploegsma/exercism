using System.Linq;
using System.Text;

public static class Transpose
{
    public static string String(string input)
    {
        if (string.IsNullOrEmpty(input))
            return "";

        var lines = input.Split('\n');
        var width = lines.Max(line => line.Length);

        var sb = new StringBuilder();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < lines.Length; j++)
            {
                var line = lines[j];
                var shouldPad = lines.Skip(j + 1).Any(x => x.Length > i);
                if (line.Length > i)
                    sb.Append(line[i]);
                else if (shouldPad)
                    sb.Append(' ');
            }

            if (i < width - 1)
                sb.Append('\n');
        }

        return sb.ToString();
    }
}
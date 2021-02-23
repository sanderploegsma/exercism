using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        var results = ReadMatchResults(inStream);
        WriteTeamStatistics(results, outStream);
    }

    private static IDictionary<string, Stats> ReadMatchResults(Stream stream)
    {
        var tournament = new Dictionary<string, Stats>();

        foreach (var line in ReadLines(stream))
        {
            var columns = line.Split(";");
            var (team1, team2, result) = (columns[0], columns[1], columns[2]);

            if (!tournament.ContainsKey(team1))
                tournament.Add(team1, new Stats());

            if (!tournament.ContainsKey(team2))
                tournament.Add(team2, new Stats());

            switch (result)
            {
                case "win":
                    tournament[team1].MatchesWon++;
                    tournament[team2].MatchesLost++;
                    break;
                case "loss":
                    tournament[team1].MatchesLost++;
                    tournament[team2].MatchesWon++;
                    break;
                case "draw":
                    tournament[team1].MatchesDrawn++;
                    tournament[team2].MatchesDrawn++;
                    break;
                default:
                    throw new ArgumentException("Invalid match result");
            }
        }

        return tournament;
    }

    private static void WriteTeamStatistics(IDictionary<string, Stats> teamStatistics, Stream stream)
    {
        var rows = teamStatistics
            .OrderByDescending(kv => kv.Value.Points)
            .ThenBy(kv => kv.Key);

        const string format = @"{0,-30} | {1,2} | {2,2} | {3,2} | {4,2} | {5,2}";

        using var writer = new StreamWriter(stream);
        writer.Write(format, "Team", "MP", "W", "D", "L", "P");

        foreach (var (team, stats) in rows)
        {
            writer.Write("\n");
            writer.Write(format, team, stats.MatchesPlayed, stats.MatchesWon, stats.MatchesDrawn, stats.MatchesLost,
                stats.Points);
        }
    }

    private static IEnumerable<string> ReadLines(Stream stream)
    {
        using var input = stream;
        using var reader = new StreamReader(input);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }

    private class Stats
    {
        private const int PointsPerWin = 3;
        private const int PointsPerDraw = 1;
        private const int PointsPerLoss = 0;
        
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public int MatchesDrawn { get; set; }
        public int MatchesPlayed => MatchesWon + MatchesDrawn + MatchesLost;
        public int Points => MatchesWon * PointsPerWin + MatchesDrawn * PointsPerDraw + MatchesLost * PointsPerLoss;
    }
}
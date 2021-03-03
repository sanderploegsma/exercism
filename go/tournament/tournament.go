package tournament

import (
	"fmt"
	"io"
	"io/ioutil"
	"sort"
	"strings"
)

const (
	pointsPerWin   = 3
	pointsPerDraw  = 1
	pointsPerLoss  = 0
	tableRowFormat = "%-30s | %2v | %2v | %2v | %2v | %2v\n"
)

type stat struct {
	Team  string
	Won   int
	Drawn int
	Lost  int
}

func (s *stat) Points() int {
	return pointsPerWin*s.Won + pointsPerDraw*s.Drawn + pointsPerLoss*s.Lost
}

func (s *stat) MatchesPlayed() int {
	return s.Won + s.Drawn + s.Lost
}

// Tally reads a CSV list of match results from the given reader
// and writes a tally table to the given writer
func Tally(r io.Reader, w io.Writer) error {
	results, err := readResults(r)
	if err != nil {
		return err
	}

	stats, err := parseStats(results)
	if err != nil {
		return err
	}

	writeStats(stats, w)
	return nil
}

func readResults(r io.Reader) ([]string, error) {
	results, err := ioutil.ReadAll(r)
	if err != nil {
		return nil, err
	}

	trimmed := strings.TrimSpace(string(results))
	return strings.Split(trimmed, "\n"), nil
}

func parseStats(results []string) ([]stat, error) {
	won := map[string]int{}
	drawn := map[string]int{}
	lost := map[string]int{}
	teams := map[string]bool{}

	for i, line := range results {
		if len(line) == 0 || strings.HasPrefix(line, "#") {
			continue
		}

		cols := strings.Split(line, ";")
		if len(cols) != 3 {
			return nil, fmt.Errorf("invalid line in input: %d", i)
		}

		team1, team2, result := cols[0], cols[1], cols[2]
		teams[team1] = true
		teams[team2] = true

		switch result {
		case "win":
			won[team1]++
			lost[team2]++
		case "draw":
			drawn[team1]++
			drawn[team2]++
		case "loss":
			lost[team1]++
			won[team2]++
		default:
			return nil, fmt.Errorf("unknown match result %s", result)
		}
	}

	stats := make([]stat, 0)
	for t := range teams {
		stat := stat{
			Team:  t,
			Won:   won[t],
			Drawn: drawn[t],
			Lost:  lost[t],
		}
		stats = append(stats, stat)
	}

	return stats, nil
}

func writeStats(stats []stat, w io.Writer) {
	sort.SliceStable(stats, func(i, j int) bool {
		if stats[i].Points() > stats[j].Points() {
			return true
		}

		if stats[i].Points() < stats[j].Points() {
			return false
		}

		return strings.Compare(stats[i].Team, stats[j].Team) < 0
	})

	fmt.Fprintf(w, tableRowFormat, "Team", "MP", "W", "D", "L", "P")
	for _, s := range stats {
		fmt.Fprintf(w, tableRowFormat, s.Team, s.MatchesPlayed(), s.Won, s.Drawn, s.Lost, s.Points())
	}
}

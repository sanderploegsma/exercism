using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private readonly int _width;
    private readonly int _height;
    private readonly char[,] _grid;

    private static readonly (int, int)[] Directions =
    {
        (-1, -1),
        (-1, 0),
        (-1, 1),
        (0, -1),
        (0, 1),
        (1, -1),
        (1, 0),
        (1, 1),
    };

    public WordSearch(string grid)
    {
        var chars = grid.Split("\n").Select(row => row.ToArray()).ToArray();
        
        // Remember: column index is horizontal (x), row index is vertical (y)
        (_width, _height) = (chars[0].Length, chars.Length);

        _grid = new char[_width, _height];

        for (int row = 0; row < _height; row++)
        for (int col = 0; col < _width; col++)
            _grid[col, row] = chars[row][col];
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(IEnumerable<string> words) =>
        words.ToDictionary(word => word, SearchWord);

    private ((int, int), (int, int))? SearchWord(string word)
    {
        for (int x1 = 0; x1 < _width; x1++)
        {
            for (int y1 = 0; y1 < _height; y1++)
            {
                // If the current character is not the start of word, skip
                if (_grid[x1, y1] != word[0])
                    continue;

                // if we found the start of word, search in all directions
                foreach (var (dx, dy) in Directions)
                {
                    int i;
                    var (x2, y2) = (x1, y1);

                    // Starting at the second character, move in the current direction
                    // while checking if the characters found match the ones in word
                    for (i = 1; i < word.Length; i++)
                    {
                        x2 += dx;
                        y2 += dy;

                        // When out of bounds, stop
                        if (x2 < 0 || y2 < 0 || x2 >= _width || y2 >= _height)
                            break;

                        // When word does not match, stop
                        if (_grid[x2, y2] != word[i])
                            break;
                    }

                    // If we travelled the whole length of the word, it's a match!
                    if (i == word.Length)
                        return ((x1 + 1, y1 + 1), (x2 + 1, y2 + 1));
                }
            }
        }

        return null;
    }
}
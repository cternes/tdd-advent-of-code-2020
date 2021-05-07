namespace day20.Provider
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class TileParser
    {
        public Tile Parse(List<string> lines)
        {
            var validLines = FilterInvalidLines(lines);

            var matrix = new List<Pixel>();
            for (var y = 0; y < validLines.Count; y++)
            {
                ParseChars(y, validLines[y], matrix);
            }

            return new Tile(GetTileId(lines[0]), matrix);
        }

        private static List<string> FilterInvalidLines(List<string> lines)
        {
            return lines.Skip(1)
                .Where(i => !string.IsNullOrEmpty(i))
                .ToList();
        }

        private void ParseChars(int y, string line, List<Pixel> matrix)
        {
            var pixels = line.Select((character, x) => new Pixel(x, y, character));
            matrix.AddRange(pixels);
        }

        private static int GetTileId(string line)
        {
            return int.Parse(line
                .Replace("Tile ", "")
                .Replace(":", ""));
        }
    }
}
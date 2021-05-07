namespace day20.Provider
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FileReader;
    using Model;

    public class TileProvider
    {
        private readonly FileReader reader;

        private readonly TileParser tileParser = new TileParser();

        public TileProvider(FileReader reader)
        {
            this.reader = reader;
        }

        public async Task<IEnumerable<Tile>> ReadTiles()
        {
            var lines = await reader.ReadLines();
            return ParseLines(lines);
        }

        private IEnumerable<Tile> ParseLines(List<string> lines)
        {
            var tileLines = new List<string>();
            foreach (var line in lines)
            {
                tileLines = ReInitTileLinesIfNecessary(line, tileLines);
                tileLines.Add(line);

                if (AnotherTileStarts(line))
                {
                    yield return tileParser.Parse(tileLines);
                }
            }
        }

        private static bool AnotherTileStarts(string line)
        {
            return string.IsNullOrWhiteSpace(line);
        }

        private static List<string> ReInitTileLinesIfNecessary(string line, List<string> tileLines)
        {
            return line.Contains("Tile") ? new List<string>() : tileLines;
        }
    }
}
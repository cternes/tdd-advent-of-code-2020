namespace day20.test.Provider
{
    using System.Collections.Generic;
    using day20.Provider;
    using FluentAssertions;
    using Xunit;

    public class TileParserTest
    {

        [Fact]
        public void ShouldParseTile()
        {
            // Arrange
            var lines = new List<string>
            {
                "Tile 3001:",
                "..##.#..#.",
                "##..#.....",
                "#...##..#.",
                "####.#...#",
                "##.##.###.",
                "",
            };

            // Act
            var tile = new TileParser().Parse(lines);

            // Assert
            tile.Id.Should().Be(3001);
            tile.GetPixel(0, 0).Should().Be('.');
            tile.GetPixel(9, 0).Should().Be('.');
            tile.GetPixel(0, 1).Should().Be('#');
            tile.GetPixel(9, 0).Should().Be('.');
            tile.GetPixel(0, 2).Should().Be('#');
            tile.GetPixel(0, 3).Should().Be('#');
            tile.GetPixel(0, 4).Should().Be('#');
            tile.GetPixel(9, 4).Should().Be('.');
        }
    }
}
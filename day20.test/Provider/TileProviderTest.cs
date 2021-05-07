namespace day20.test.Provider
{
    using System.Linq;
    using System.Threading.Tasks;
    using day20.Provider;
    using FileReader;
    using FluentAssertions;
    using Xunit;

    public class TileProviderTest
    {
        [Fact]
        public async Task ShouldReadTiles()
        {
            // Arrange
            var reader = new FileReader("TestData/input.txt");
            var provider = new TileProvider(reader);

            // Act
            var result = await provider.ReadTiles();

            // Assert
            var tiles = result.ToList();
            tiles[0].Id.Should().Be(3001);
            tiles[1].Id.Should().Be(2069);
            tiles.Count().Should().Be(2);
        }       
    }
}
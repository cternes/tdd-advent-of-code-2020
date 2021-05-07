namespace FileReader.test
{
    using FluentAssertions;
    using Xunit;

    public class FileReaderTest
    {
        [Fact]
        public async void ShouldReadAllLines()
        {
            // Arrange
            var provider = new FileReader("TestData/input.txt");

            // Act
            var lines = await provider.ReadLines();

            // Assert
            lines.Count.Should().Be(10);
            lines[0].Should().Be("AAA");
            lines[^1].Should().Be("XXX");
        }
    }
}
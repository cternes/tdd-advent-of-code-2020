namespace day5.test.Provider
{
    using day5.Provider;
    using FluentAssertions;
    using Xunit;

    public class DataProviderTest
    {
        [Fact]
        public async void ShouldReadAllInstructions()
        {
            // Arrange
            var provider = new DataProvider("TestData/input.txt");

            // Act
            var instructions = await provider.ReadInstructions();

            // Assert
            instructions.Count.Should().Be(10);
            instructions[0].Should().Be("AAA");
            instructions[^1].Should().Be("XXX");
        }
    }
}
namespace day14.test.Provider
{
    using day14.Provider;
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
            var instructions = await provider.ReadInput();

            // Assert
            instructions.Count.Should().Be(4);
            instructions[0].Should().Be("mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");
            instructions[^1].Should().Be("mem[8] = 0");
        }
    }
}
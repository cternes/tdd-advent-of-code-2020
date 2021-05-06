namespace day12.test.Provider
{
    using day12.Provider;
    using FluentAssertions;
    using Xunit;

    public class InstructionProviderTest
    {
        [Fact]
        public async void ShouldReadAllInstructions()
        {
            // Arrange
            var provider = new InstructionProvider("TestData/input.txt");

            // Act
            var instructions = await provider.ReadInstructions();

            // Assert
            instructions.Count.Should().Be(779);
            instructions[0].Should().Be("S3");
            instructions[^1].Should().Be("F51");
        }
    }
}
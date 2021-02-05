using Xunit;

namespace app.test
{
    using System.Collections.Generic;
    using FluentAssertions;

    public class NavigationSystemTest
    {
        [Fact]
        public void ShouldFollowInstructionsAndCalculateManhattanDistance()
        {
            // Arrange
            var instructions = new List<string>
            {
                "F10",
                "N3",
                "F7",
                "R90",
                "F11"
            };

            // Act
            var distance = new NavigationSystem(instructions).CalculateManhattanDistance();

            // Assert
            distance.Should().Be(25);
        }
    }
}

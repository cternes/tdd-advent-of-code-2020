using Xunit;

namespace app.test
{
    using System;
    using System.Collections.Generic;
    using Exception;
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

            var navigationSystem = new NavigationSystem(instructions);

            // Act
            var distance = navigationSystem.CalculateManhattanDistance();

            // Assert
            distance.Should().Be(25);
        }

        [Fact]
        public void ShouldExecuteAllPossibleInstructionsAndCalculateManhattanDistance()
        {
            // Arrange
            var instructions = new List<string>
            {
                "N100",
                "S10",
                "E100",
                "W10",
                "F10",
                "R90",
                "F10",
                "L90",
                "F10"
            };

            var navigationSystem = new NavigationSystem(instructions);

            // Act
            var distance = navigationSystem.CalculateManhattanDistance();

            // Assert
            distance.Should().Be(190);
        }


        [Fact]
        public void ShouldThrowWhenActionIsInvalid()
        {
            // Arrange
            var instructions = new List<string>
            {
                "S10", // valid
                "X100", // invalid
            };

            // Act
            Action followInstructions = () =>
            {
                _ = new NavigationSystem(instructions);
            };

            // Assert
            followInstructions.Should().Throw<InvalidActionException>();
        }
    }
}

namespace day15.test
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public class GameTest
    {

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 3)]
        [InlineData(3, 6)]
        [InlineData(4, 0)]
        [InlineData(5, 3)]
        [InlineData(6, 3)]
        [InlineData(7, 1)]
        [InlineData(8, 0)]
        [InlineData(9, 4)]
        [InlineData(10, 0)]
        public void ShouldReturnExpectedAfterNTurns(int turns, int expected)
        {
            // Arrange
            var game = CreateGame(0,3,6);

            // Act
            var result = -1;
            for (var i = 0; i < turns; i++)
            {
                result = game.Play();
            }

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void ShouldReturn1After2020Turns()
        {
            // Arrange
            var game = CreateGame(1,3,2);

            // Act
            var result = -1;
            for (var i = 0; i < 2020; i++)
            {
                result = game.Play();
            }

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public void ShouldReturn10After2020Turns()
        {
            // Arrange
            var game = CreateGame(2,1,3);

            // Act
            var result = -1;
            for (var i = 0; i < 2020; i++)
            {
                result = game.Play();
            }

            // Assert
            result.Should().Be(10);
        }
        
        [Fact]
        public void ShouldReturn27After2020Turns()
        {
            // Arrange
            var game = CreateGame(1,2,3);

            // Act
            var result = -1;
            for (var i = 0; i < 2020; i++)
            {
                result = game.Play();
            }

            // Assert
            result.Should().Be(27);
        }

        [Fact]
        public void ShouldReturn78After2020Turns()
        {
            // Arrange
            var game = CreateGame(2,3,1);

            // Act
            var result = -1;
            for (var i = 0; i < 2020; i++)
            {
                result = game.Play();
            }

            // Assert
            result.Should().Be(78);
        }

        [Fact]
        public void ShouldReturn1836After2020Turns()
        {
            // Arrange
            var game = CreateGame(3,1,2);

            // Act
            var result = -1;
            for (var i = 0; i < 2020; i++)
            {
                result = game.Play();
            }

            // Assert
            result.Should().Be(1836);
        }

        [Fact]
        public void ShouldReturnResultAfter2020Turns()
        {
            // Arrange
            var game = CreateGame(8,0,17,4,1,12);

            // Act
            var result = -1;
            for (var i = 0; i < 2020; i++)
            {
                result = game.Play();
            }

            // Assert
            result.Should().Be(981);
        }
        
        [Fact]
        public void ShouldReturn18After30MioTurns()
        {
            // Arrange
            var game = CreateGame(3,2,1);

            // Act
            var result = -1;
            for (var i = 0; i < 30_000_000; i++)
            {
                result = game.Play();
            }

            // Assert
            result.Should().Be(18);
        }

        private static Game CreateGame(params int[] numbers)
        {
            var startingNumbers = new List<int>();
            startingNumbers.AddRange(numbers);

            var game = new Game(startingNumbers);
            return game;
        }

    }
}
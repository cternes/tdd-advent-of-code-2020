namespace app.test.Model
{
    using app.Model;
    using FluentAssertions;
    using Xunit;

    public class ShipTest
    {
        private const int North = 0;
        private const int East = 90;
        private const int South = 180;

        [Fact]
        public void ShouldMoveNorthRelativeToPosition()
        {
            // Arrange
            var ship = CreateShip();

            // Act
            var pos = ship.MoveNorth(10);

            // Assert
            AssertThatShipMovedNorth(pos);
        }

        [Fact]
        public void ShouldMoveNorthMultipleTimes()
        {
            // Arrange
            var ship = CreateShip();
            ship.MoveNorth(10);

            // Act
            var pos = ship.MoveNorth(10);
            
            // Assert
            pos.X.Should().Be(100);
            pos.Y.Should().Be(120);
        }

        [Fact]
        public void ShouldMoveSouthRelativeToPosition()
        {
            // Arrange
            var ship = CreateShip();

            // Act
            var pos = ship.MoveSouth(10);

            // Assert
            AssertThatShipMovedSouth(pos);
        }


        [Fact]
        public void ShouldMoveEastRelativeToPosition()
        {
            // Arrange
            var ship = CreateShip();

            // Act
            var pos = ship.MoveEast(10);

            // Assert
            AssertThatShipMovedEast(pos);
        }


        [Theory]
        [InlineData(East)]
        [InlineData(South)]
        public void ShouldRotateRight(int degree)
        {
            // Arrange
            var ship = CreateShip();

            // Act
            var direction = ship.RotateRight(degree);

            // Assert
            direction.Should().Be(degree);
        }


        [Fact]
        public void ShouldRotateRightRelativeToDirection()
        {
            // Arrange
            var ship = CreateShip(East);

            // Act
            var direction = ship.RotateRight(East);

            // Assert
            direction.Should().Be(South);
        }


        [Fact]
        public void ShouldRotateMultipleTimes()
        {
            // Arrange
            var ship = CreateShip();
            ship.RotateRight(East);

            // Act
            var direction = ship.RotateRight(90);

            // Assert
            direction.Should().Be(South);
        }


        [Theory]
        [InlineData(North)]
        [InlineData(East)]
        [InlineData(South)]
        public void ShouldMoveForwardToNorth(int direction)
        {
            // Arrange
            var ship = CreateShip(direction);

            // Act
            var pos = ship.MoveForward(10);

            // Assert
            switch (direction)
            {
                case North: AssertThatShipMovedNorth(pos);
                    break;
                case East: AssertThatShipMovedEast(pos);
                    break;
                case South: AssertThatShipMovedSouth(pos);
                    break;
            }
        }


        [Theory]
        [InlineData(100, 100, 200)]
        [InlineData(50, 50, 100)]
        [InlineData(-100, -100, 200)]
        public void ShouldCalculateManhattanDistance(int x, int y, int expectedDistance)
        {
            // Arrange
            var ship = new Ship(new Position
            {
                X = x,
                Y = y
            }, 0);

            // Act
            var distance = ship.CalculateManhattanDistance();

            // Assert
            distance.Should().Be(expectedDistance);
        }

        private static void AssertThatShipMovedEast(Position pos)
        {
            pos.X.Should().Be(110);
            pos.Y.Should().Be(100);
        }

        private static void AssertThatShipMovedNorth(Position pos)
        {
            pos.X.Should().Be(100);
            pos.Y.Should().Be(110);
        }

        private static void AssertThatShipMovedSouth(Position pos)
        {
            pos.X.Should().Be(100);
            pos.Y.Should().Be(90);
        }

        private static Ship CreateShip(int direction = 0)
        {
            return new Ship(new Position
            {
                X = 100,
                Y = 100
            }, direction);
        }
    }
}
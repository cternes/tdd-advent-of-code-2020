namespace app.test.Model
{
    using System;
    using app.Model;
    using Exception;
    using FluentAssertions;
    using Xunit;

    public class ShipTest
    {
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

        [Fact]
        public void ShouldMoveWestRelativeToPosition()
        {
            // Arrange
            var ship = CreateShip();

            // Act
            var pos = ship.MoveWest(10);

            // Assert
            AssertThatShipMovedWest(pos);
        }

        [Theory]
        [InlineData(Constants.East)]
        [InlineData(Constants.South)]
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
            var ship = CreateShip(Constants.East);

            // Act
            var direction = ship.RotateRight(90);

            // Assert
            direction.Should().Be(Constants.South);
        }


        [Fact]
        public void ShouldRotateToEast()
        {
            // Arrange
            var ship = CreateShip(Constants.West);

            // Act
            var direction = ship.RotateRight(180);

            // Assert
            direction.Should().Be(Constants.East);
        }

        [Fact]
        public void ShouldRotateToWest()
        {
            // Arrange
            var ship = CreateShip(Constants.East);

            // Act
            var direction = ship.RotateLeft(180);

            // Assert
            direction.Should().Be(Constants.West);
        }

        [Fact]
        public void ShouldRotateLeftRelativeToDirection()
        {
            // Arrange
            var ship = CreateShip(Constants.East);

            // Act
            var direction = ship.RotateLeft(90);

            // Assert
            direction.Should().Be(Constants.North);
        }

        [Fact]
        public void ShouldRotateMultipleTimes()
        {
            // Arrange
            var ship = CreateShip();
            ship.RotateRight(Constants.East);

            // Act
            var direction = ship.RotateRight(90);

            // Assert
            direction.Should().Be(Constants.South);
        }

        [Theory]
        [InlineData(Constants.North)]
        [InlineData(Constants.NorthFullAngle)]
        [InlineData(Constants.East)]
        [InlineData(Constants.South)]
        [InlineData(Constants.West)]
        public void ShouldMoveForwardToNorth(int direction)
        {
            // Arrange
            var ship = CreateShip(direction);

            // Act
            var pos = ship.MoveForward(10);

            // Assert
            switch (direction)
            {
                case Constants.North: AssertThatShipMovedNorth(pos);
                    break;
                case Constants.NorthFullAngle: AssertThatShipMovedNorth(pos);
                    break;
                case Constants.East: AssertThatShipMovedEast(pos);
                    break;
                case Constants.South: AssertThatShipMovedSouth(pos);
                    break;
                case Constants.West: AssertThatShipMovedWest(pos);
                    break;
            }
        }

        [Fact]
        public void ShouldThrowWhenDirectionIsInvalid()
        {
            // Arrange
            var ship = CreateShip();
            ship.RotateRight(10);

            // Act
            Action moveForward = () => ship.MoveForward(10);

            // Assert
            moveForward.Should().Throw<InvalidDirectionException>();
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

        private static void AssertThatShipMovedWest(Position pos)
        {
            pos.X.Should().Be(90);
            pos.Y.Should().Be(100);
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
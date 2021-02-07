namespace app.test.Model
{
    using app.Model;
    using app.Model.Ship;
    using FluentAssertions;
    using Xunit;

    public class WaypointFerryTest
    {
        [Fact]
        public void ShouldMoveTowardsWaypoint()
        {
            // Arrange
            var ship = CreateShip();

            // Act
            var position = ship.MoveForward(10);

            // Assert
            position.X.Should().Be(100);
            position.Y.Should().Be(10);
        }

        [Fact]
        public void ShouldMoveForwardMultipleTimes()
        {
            // Arrange
            var ship = CreateShip();

            // Act
            ship.MoveForward(10);
            var position = ship.MoveForward(10);

            // Assert
            position.X.Should().Be(200);
            position.Y.Should().Be(20);
        }

        [Fact]
        public void ShouldMoveWaypointToNorth()
        {
            // Arrange
            var ship = CreateShip();

            // Act
            ship.MoveNorth(10);

            // Assert
            ship.Waypoint.X.Should().Be(10);
            ship.Waypoint.Y.Should().Be(11);
        }

        [Fact]
        public void ShouldMoveWaypointToSouth()
        {
            // Arrange
            var ship = CreateShip();

            // Act
            ship.MoveSouth(10);

            // Assert
            ship.Waypoint.X.Should().Be(10);
            ship.Waypoint.Y.Should().Be(-9);
        }

        [Fact]
        public void ShouldMoveWaypointToEast()
        {
            // Arrange
            var ship = CreateShip();

            // Act
            ship.MoveEast(10);

            // Assert
            ship.Waypoint.X.Should().Be(20);
            ship.Waypoint.Y.Should().Be(1);
        }

        [Fact]
        public void ShouldMoveWaypointToWest()
        {
            // Arrange
            var ship = CreateShip();

            // Act
            ship.MoveWest(10);

            // Assert
            ship.Waypoint.X.Should().Be(0);
            ship.Waypoint.Y.Should().Be(1);
        }

        [Fact]
        public void ShouldRotateWaypointClockwise()
        {
            // Arrange
            var ship = new WaypointFerry(new Position
            {
                X = 10,
                Y = 4
            }, 0);

            // Act
            ship.RotateRight(Constants.East);

            // Assert
            ship.Waypoint.X.Should().Be(4);
            ship.Waypoint.Y.Should().Be(-10);
        }

        [Fact]
        public void ShouldRotateWaypointCounterClockwise()
        {
            // Arrange
            var ship = new WaypointFerry(new Position
            {
                X = 10,
                Y = 4
            }, 0);

            // Act
            ship.RotateLeft(Constants.East);

            // Assert
            ship.Waypoint.X.Should().Be(-4);
            ship.Waypoint.Y.Should().Be(10);
        }

        private static WaypointFerry CreateShip(int direction = 0)
        {
            return new WaypointFerry(new Position
            {
                X = 10,
                Y = 1
            }, direction);
        }
    }
}
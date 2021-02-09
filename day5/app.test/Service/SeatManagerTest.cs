namespace app.test.Service
{
    using System.Collections.Generic;
    using app.Model;
    using app.Service;
    using FluentAssertions;
    using Xunit;

    public class SeatManagerTest
    {
        [Fact]
        public void ShouldFindMissingSeats()
        {
            // Arrange
            var seats = new List<Seat>
            {
                new Seat(0, 1),
                new Seat(0, 2),
                new Seat(0, 3),
                new Seat(0, 4),
            };

            // Act
            var missingSeats = new SeatManager().GetMissingSeats(seats, 1, 9);

            // Assert
            missingSeats.Should().Contain(new[] {5, 6, 7, 8});
        }
    }
}
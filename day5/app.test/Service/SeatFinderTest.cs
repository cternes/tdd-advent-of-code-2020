namespace app.test.Service
{
    using app.Service;
    using FluentAssertions;
    using Xunit;

    public class SeatFinderTest
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 44, 5, 357)]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void ShouldFindSeat(string input, int expectedRow, int expectedCol, int expectedSeatId)
        {
            // Arrange
            var seatFinder = new SeatFinder();

            // Act
            var seat = seatFinder.FindSeat(input);

            // Assert
            seat.Row.Should().Be(expectedRow);
            seat.Col.Should().Be(expectedCol);
            seat.Id.Should().Be(expectedSeatId);
        }
    }
}
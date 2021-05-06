namespace day5.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class SeatManager
    {
        private List<Seat> SortSeats(List<Seat> seats)
        {
            return seats
                .OrderBy(i => i.Id)
                .ToList();
        }

        public List<int> GetMissingSeats(List<Seat> seats, int minSeatId, int maxSeatId)
        {
            var sortedSeats = SortSeats(seats);
            var seatIds = sortedSeats.Select(i => i.Id);

            return Enumerable.Range(minSeatId, maxSeatId-minSeatId)
                .Except(seatIds)
                .ToList();
        }
    }
}
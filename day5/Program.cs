namespace day5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Model;
    using Provider;
    using Service;

    public static class Program
    {
        public static async Task Main()
        {
            var instructions = await ReadInstruction();

            var seats = SolvePartOne(instructions);

            Console.WriteLine("===");

            SolvePartTwo(seats);
        }

        private static async Task<List<string>> ReadInstruction()
        {
            var provider = new DataProvider("Input/input.txt");
            return await provider.ReadInstructions();
        }

        private static List<Seat> SolvePartOne(List<string> lines)
        {
            Console.WriteLine("Part I");

            var seats = new List<Seat>();
            foreach (var line in lines)
            {
                seats.Add(new SeatFinder().FindSeat(line));
            }

            var maxSeatId = seats.Max(i => i.Id);

            Console.WriteLine($"Max seat Id: {maxSeatId}");

            return seats;
        }

        private static void SolvePartTwo(List<Seat> seats)
        {
            Console.WriteLine("Part II");

            var missingSeats = new SeatManager().GetMissingSeats(seats, 61, 994);

            Console.WriteLine($"Missing seats:");
            foreach (var seatId in missingSeats)
            {
                Console.WriteLine(seatId);
            }
            
        }
    }
}
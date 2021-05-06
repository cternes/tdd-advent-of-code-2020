namespace day7
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Provider;
    using Service;

    public static class Program
    {
        public static async Task Main()
        {
            var rules = await ReadRules();

            SolvePartOne(rules);

            //Console.WriteLine("===");

            //SolvePartTwo(seats);
        }

        private static async Task<List<string>> ReadRules()
        {
            var provider = new DataProvider("Input/input.txt");
            return await provider.ReadInstructions();
        }

        private static void SolvePartOne(List<string> rules)
        {
            Console.WriteLine("Part I");

            var numberOfColors = new RuleService(rules).GetNumberOfOuterBags("shiny gold");

            Console.WriteLine($"Number of colors: {numberOfColors}");
        }

        //private static void SolvePartTwo(List<Seat> seats)
        //{
        //    Console.WriteLine("Part II");

        //    var missingSeats = new SeatManager().GetMissingSeats(seats, 61, 994);

        //    Console.WriteLine($"Missing seats:");
        //    foreach (var seatId in missingSeats)
        //    {
        //        Console.WriteLine(seatId);
        //    }

        //}
    }
}
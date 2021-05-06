namespace day12
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;
    using Model.Ship;
    using Provider;

    public static class Program
    {
        public static async Task Main()
        {
            var instructions = await ReadInstruction();

            SolvePartOne(instructions);

            Console.WriteLine("===");

            SolvePartTwo(instructions);
        }

        private static async Task<List<string>> ReadInstruction()
        {
            var provider = new InstructionProvider("Input/input.txt");
            return await provider.ReadInstructions();
        }

        private static void SolvePartOne(List<string> instructions)
        {
            Console.WriteLine("Part I");
            
            var ship = new Ship(Position.HomePosition(), Constants.East);
            var distance = new NavigationSystem(ship, instructions).CalculateManhattanDistance();

            Console.WriteLine($"ManhattanDistance: {distance}");
        }

        private static void SolvePartTwo(List<string> instructions)
        {
            Console.WriteLine("Part II");

            var ship = new WaypointFerry(new Position
            {
                X = 10,
                Y = 1
            }, Constants.East);
            
            var distance = new NavigationSystem(ship, instructions).CalculateManhattanDistance();

            Console.WriteLine($"ManhattanDistance: {distance}");
        }
    }
}
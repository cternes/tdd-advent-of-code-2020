using System;

namespace app
{
    using System.Threading.Tasks;
    using Provider;

    public static class Program
    {
        public static async Task Main()
        {
            var provider = new InstructionProvider("Input/input.txt");
            var instructions = await provider.ReadInstructions();
            var distance = new NavigationSystem(instructions).CalculateManhattanDistance();

            Console.WriteLine($"ManhattanDistance: {distance}");
        }
    }
}
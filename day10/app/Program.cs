namespace app
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Provider;

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

        }
    }
}
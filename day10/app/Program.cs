namespace app
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
            var adapters = await ReadAdapters();

            SolvePartOne(adapters);

            //Console.WriteLine("===");

            //SolvePartTwo(seats);
        }

        private static async Task<List<int>> ReadAdapters()
        {
            var provider = new DataProvider("Input/input.txt");
            return await provider.ReadLines();
        }

        private static void SolvePartOne(List<int> adapters)
        {
            Console.WriteLine("Part I");

            var adapterBag = new AdapterBag(adapters);
            adapterBag.CheckAllAdapters();

            var result = adapterBag.NumberOf1JoltDifferences * adapterBag.NumberOf3JoltDifferences;
            Console.WriteLine($"Result: {result}");
        }
    }
}
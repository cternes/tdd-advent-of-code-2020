namespace app
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Provider;

    public static class Program
    {
        public static async Task Main()
        {
            var lines = await ReadFile();

            SolvePartOne(lines);
        }

        private static async Task<List<string>> ReadFile()
        {
            var provider = new DataProvider("Input/input.txt");
            return await provider.ReadInput();
        }

        private static void SolvePartOne(List<string> lines)
        {
            //Console.WriteLine("Part I");
            //var sum = new PortComputer().ProcessInput(lines);

            //Console.WriteLine($"sum: {sum}");
        }
    }
}
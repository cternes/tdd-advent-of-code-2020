namespace day10.Provider
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    public class DataProvider
    {
        private readonly string filePath;

        public DataProvider(string filePath)
        {
            this.filePath = filePath;
        }

        public async Task<List<int>> ReadLines()
        {
            var lines = await File.ReadAllLinesAsync(filePath);

            var numbers = new List<int>();
            foreach (var line in lines)
            {
                numbers.Add(int.Parse(line));
            }

            return numbers;
        }
    }
}
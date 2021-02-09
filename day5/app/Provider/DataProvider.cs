namespace app.Provider
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataProvider
    {
        private readonly string filePath;

        public DataProvider(string filePath)
        {
            this.filePath = filePath;
        }

        public async Task<List<string>> ReadInstructions()
        {
            var allLines = await File.ReadAllLinesAsync(filePath);
            return allLines.ToList();
        }
    }
}
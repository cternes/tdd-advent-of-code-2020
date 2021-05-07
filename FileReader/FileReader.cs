namespace FileReader
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class FileReader
    {
        private readonly string filePath;

        public FileReader(string filePath)
        {
            this.filePath = filePath;
        }

        public async Task<List<string>> ReadLines()
        {
            var allLines = await File.ReadAllLinesAsync(filePath);
            return allLines.ToList();
        }
    }
}
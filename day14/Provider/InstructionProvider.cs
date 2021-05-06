namespace day14.Provider
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class InstructionProvider
    {
        private readonly string filePath;

        public InstructionProvider(string filePath)
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
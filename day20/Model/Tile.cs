namespace day20.Model
{
    using System.Collections.Generic;
    using System.Linq;

    public class Tile
    {
        public int Id { get; }

        private readonly List<Pixel> matrix;

        public Tile(int id, List<Pixel> matrix)
        {
            Id = id;
            this.matrix = matrix;
        }

        public char GetPixel(int x, int y)
        {
            return matrix.Single(i => i.X == x && i.Y == y).Value;
        }
    }
}
namespace app.Model
{
    public class Position
    {
        public int X { get; set; }

        public int Y { get; set; }

        public static Position HomePosition()
        {
            return new Position
            {
                X = 0,
                Y = 0
            };
        }
    }
}
namespace app.Model
{
    public class Seat
    {
        public int Row { get; }

        public int Col { get;  }

        public int Id => Row * 8 + Col;

        public Seat(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
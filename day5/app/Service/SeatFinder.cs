namespace app.Service
{
    using Model;

    public class SeatFinder
    {
        private Node rowNode;
        private Node colNode;

        public SeatFinder()
        {
            rowNode = new Node(0, 127);
            colNode = new Node(0, 7);
        }

        private void ProcessInput(string input)
        {
            foreach (var character in input)
            {
                var command = (Command) character;
                switch (command)
                {
                    case Command.Left:
                        colNode = colNode.Left;
                        break;
                    case Command.Right:
                        colNode = colNode.Right;
                        break;
                    case Command.Front: rowNode = rowNode.Left;
                        break;
                    case Command.Back: rowNode = rowNode.Right;
                        break;
                }
            }
        }

        public Seat FindSeat(string input)
        {
            ProcessInput(input);
            return new Seat(rowNode.Data.Min, colNode.Data.Min);
        }
    }
}
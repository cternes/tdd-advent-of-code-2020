namespace app.Model
{
    internal class Command
    {
        public ActionType Action { get; }

        public int Value { get;  }

        public Command(string instruction)
        {
            Action = (ActionType) instruction[0];
            Value = int.Parse(instruction[1..]);
        }
    }
}
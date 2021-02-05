namespace app
{
    using System.Collections.Generic;
    using Model;

    public class NavigationSystem
    {
        private readonly Ship ship;

        public NavigationSystem(List<string> instructions)
        {
            ship = new Ship(new Position
            {
                X = 0,
                Y = 0
            }, 90);

            FollowInstructions(instructions);
        }

        private void FollowInstructions(List<string> instructions)
        {
            foreach (var instruction in instructions)
            {
                var command = new Command(instruction);
                ExecuteCommand(command);
            }
        }

        private void ExecuteCommand(Command command)
        {
            switch (command.Action)
            {
                case ActionType.MoveForward:
                    ship.MoveForward(command.Value);
                    break;
                case ActionType.MoveNorth:
                    ship.MoveNorth(command.Value);
                    break;
                case ActionType.RotateRight:
                    ship.RotateRight(command.Value);
                    break;
            }
        }

        public int CalculateManhattanDistance()
        {
            return ship.CalculateManhattanDistance();
        }
    }
}
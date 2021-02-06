namespace app
{
    using System.Collections.Generic;
    using Exception;
    using Model;

    public class NavigationSystem
    {
        private readonly Ship ship;

        public NavigationSystem(List<string> instructions)
        {
            ship = new Ship(Position.HomePosition(), Constants.East);

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
                case ActionType.MoveNorth:
                    ship.MoveNorth(command.Value);
                    break;
                case ActionType.MoveSouth:
                    ship.MoveSouth(command.Value);
                    break;
                case ActionType.MoveEast:
                    ship.MoveEast(command.Value);
                    break;
                case ActionType.MoveWest:
                    ship.MoveWest(command.Value);
                    break;
                case ActionType.RotateLeft:
                    ship.RotateLeft(command.Value);
                    break;
                case ActionType.RotateRight:
                    ship.RotateRight(command.Value);
                    break;
                case ActionType.MoveForward:
                    ship.MoveForward(command.Value);
                    break;
                default:
                    throw new InvalidActionException($"Unknown action type {command.Action}");
            }
        }

        public int CalculateManhattanDistance()
        {
            return ship.CalculateManhattanDistance();
        }
    }
}
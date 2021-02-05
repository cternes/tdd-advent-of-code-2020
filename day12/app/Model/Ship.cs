namespace app.Model
{
    using System;

    public class Ship
    {
        private Position position;
        private int direction;

        public Ship(Position position, int direction)
        {
            this.position = position;
            this.direction = direction;
        }

        public Position MoveNorth(int value)
        {
            position =  new Position
            {
                X = position.X,
                Y = position.Y + value
            };

            return position;
        }

        public Position MoveSouth(int value)
        {
            position =  new Position
            {
                X = position.X,
                Y = position.Y - value
            };

            return position;
        }

        public Position MoveEast(int value)
        {
            position =  new Position
            {
                X = position.X + value,
                Y = position.Y
            };

            return position;
        }

        public int RotateRight(int degree)
        {
            direction += degree;
            return direction;
        }

        public Position MoveForward(int value)
        {
            return direction switch
            {
                0 => MoveNorth(value),
                90 => MoveEast(value),
                180 => MoveSouth(value),
                _ => throw new NotImplementedException($"Cannot move to direction {direction}")
            };
        }

        public int CalculateManhattanDistance()
        {
            return Math.Abs(position.X) + Math.Abs(position.Y);
        }
    }
}
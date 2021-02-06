namespace app.Model
{
    using System;
    using Exception;

    public class Ship
    {
        private const int CompleteAngle = 360;
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
        public Position MoveWest(int value)
        {
            position =  new Position
            {
                X = position.X - value,
                Y = position.Y
            };

            return position;
        }

        public int RotateRight(int degree)
        {
            direction += degree;

            if (direction >  CompleteAngle)
            {
                direction = Math.Abs(CompleteAngle - direction);
            }
            else if (direction > CompleteAngle)
            {
                direction = CompleteAngle - direction;
            }

            return direction;
        }

        public int RotateLeft(int degree)
        {
            direction -= degree;

            if (direction < 0)
            {
                direction = CompleteAngle - Math.Abs(direction);
            }
            else if (direction > CompleteAngle)
            {
                direction = CompleteAngle - direction;
            }

            return direction;
        }

        public Position MoveForward(int value)
        {
            return direction switch
            {
                0 => MoveNorth(value),
                90 => MoveEast(value),
                180 => MoveSouth(value),
                270 => MoveWest(value),
                360 => MoveNorth(value),
                _ => throw new InvalidDirectionException($"Cannot move to direction {direction}")
            };
        }
        
        public int CalculateManhattanDistance()
        {
            return Math.Abs(position.X) + Math.Abs(position.Y);
        }
    }
}
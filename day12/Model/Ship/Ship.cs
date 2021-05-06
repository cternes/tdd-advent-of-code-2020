namespace day12.Model.Ship
{
    using System;
    using Exception;

    public class Ship : IShip
    {
        private const int CompleteAngle = 360;
        protected Position Position;
        public int Direction { get; private set; }

        public Ship(Position position, int direction)
        {
            Position = position;
            Direction = direction;
        }

        protected virtual Position GetReferencePoint()
        {
            return Position;
        }

        protected virtual void MoveReferencePoint(Position newPosition)
        {
            Position = newPosition;
        }

        public Position MoveNorth(int value)
        {
            var newPosition = new Position
            {
                X = GetReferencePoint().X,
                Y = GetReferencePoint().Y + value
            };

            MoveReferencePoint(newPosition);

            return newPosition;
        }

        public Position MoveSouth(int value)
        {
            var newPosition =  new Position
            {
                X = GetReferencePoint().X,
                Y = GetReferencePoint().Y - value
            };

            MoveReferencePoint(newPosition);

            return newPosition;
        }

        public Position MoveEast(int value)
        {
            var newPosition =  new Position
            {
                X = GetReferencePoint().X + value,
                Y = GetReferencePoint().Y
            };

            MoveReferencePoint(newPosition);

            return newPosition;
        }
        public Position MoveWest(int value)
        {
            var newPosition =  new Position
            {
                X = GetReferencePoint().X - value,
                Y = GetReferencePoint().Y
            };

            MoveReferencePoint(newPosition);

            return newPosition;
        }

        public virtual void RotateRight(int degree)
        {
            Direction += degree;

            if (Direction >  CompleteAngle)
            {
                Direction = Math.Abs(CompleteAngle - Direction);
            }
            else if (Direction > CompleteAngle)
            {
                Direction = CompleteAngle - Direction;
            }
        }

        public virtual void RotateLeft(int degree)
        {
            Direction -= degree;

            if (Direction < 0)
            {
                Direction = CompleteAngle - Math.Abs(Direction);
            }
            else if (Direction > CompleteAngle)
            {
                Direction = CompleteAngle - Direction;
            }
        }

        public virtual Position MoveForward(int value)
        {
            return Direction switch
            {
                0 => MoveNorth(value),
                90 => MoveEast(value),
                180 => MoveSouth(value),
                270 => MoveWest(value),
                360 => MoveNorth(value),
                _ => throw new InvalidDirectionException($"Cannot move to direction {Direction}")
            };
        }
        
        public int CalculateManhattanDistance()
        {
            return Math.Abs(Position.X) + Math.Abs(Position.Y);
        }
    }
}
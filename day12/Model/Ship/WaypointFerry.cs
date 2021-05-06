namespace day12.Model.Ship
{
    using System;

    public class WaypointFerry : Ship
    {
        public Position Waypoint { get; private set; }

        public WaypointFerry(Position waypoint, int direction) 
            : base(Position.HomePosition(), direction)
        {
            Waypoint = waypoint;
        }

        protected override Position GetReferencePoint()
        {
            return Waypoint;
        }

        protected override void MoveReferencePoint(Position newPosition)
        {
            Waypoint = newPosition;
        }

        public override Position MoveForward(int value)
        {
            Position = new Position
            {
                X = Position.X + Waypoint.X * value,
                Y = Position.Y + Waypoint.Y * value
            };

            return Position;
        }

        public override void RotateRight(int degree)
        {
            degree *= -1;

            Waypoint = Rotate(degree);
        }

        public override void RotateLeft(int degree)
        {
            Waypoint = Rotate(degree);
        }

        private Position Rotate(int degree)
        {
            var angle = Math.PI / 180 * degree;
            var x = Waypoint.X * Math.Cos(angle) - Waypoint.Y * Math.Sin(angle);
            var y = Waypoint.Y * Math.Cos(angle) + Waypoint.X * Math.Sin(angle);

            return new Position
            {
                X = (int) Math.Round(x),
                Y = (int) Math.Round(y)
            };
        }
    }
}
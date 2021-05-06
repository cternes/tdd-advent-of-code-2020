namespace day12.Model.Ship
{
    public interface IShip
    {
        Position MoveNorth(int value);

        Position MoveSouth(int value);
        
        Position MoveEast(int value);
        
        Position MoveWest(int value);
        
        void RotateLeft(int degree);
        
        void RotateRight(int degree);
        
        Position MoveForward(int value);
        
        int CalculateManhattanDistance();
    }
}
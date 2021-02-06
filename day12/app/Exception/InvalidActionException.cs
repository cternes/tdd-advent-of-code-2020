namespace app.Exception
{
    using System;

    public class InvalidActionException : Exception
    {
        public InvalidActionException(string message) 
            : base(message)
        {
        }
    }
}
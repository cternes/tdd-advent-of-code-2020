namespace day12.Exception
{
    using System;

    public class InvalidDirectionException : Exception
    {
        public InvalidDirectionException(string message) 
            : base(message)
        {
        }
    }
}
using System;

namespace MarsRover.Core.Exceptions
{
    public class InvalidAction : Exception
    {
        public InvalidAction() : base(ErrorMessages.InvalidCommand)
        {

        }

        public InvalidAction(string message) : base(message)
        {
        }
    }
}

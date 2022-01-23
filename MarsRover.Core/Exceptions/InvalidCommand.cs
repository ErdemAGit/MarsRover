using System;

namespace MarsRover.Core.Exceptions
{
    public class InvalidCommand : Exception
    {
        public InvalidCommand() : base(ErrorMessages.InvalidCommand)
        {

        }

        public InvalidCommand(string message) : base(message)
        {
        }
    }
}

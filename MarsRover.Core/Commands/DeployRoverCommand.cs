using System;

namespace MarsRover.Core.Commands
{
    public class DeployRoverCommand : ICommand, IDeployRoverCommand
    {
        public string Command { get; set; }
        private IRover _rover;
        private IPosition _position;
        private IPlateauGrid _plateauGrid;

        public DeployRoverCommand(IRover rover, IPosition position)
        {
            _rover = rover;
            _position = position;
        }

        public void Initialize(IPlateauGrid plateauGrid, string command)
        {
            _plateauGrid = plateauGrid;
            Command = command;
        }

        public void Process()
        {
            string[] commandParams = Command.Split(' ');
            _position.X = Int32.Parse(commandParams[0]);
            _position.Y = Int32.Parse(commandParams[1]);
            _position.Direction = CharToDirection(Char.Parse(commandParams[2]));

            _rover.Deploy(_position);
        }

        public IRover GetRover()
        {
            return _rover;
        }

        private Direction CharToDirection(char command)
        {
            switch (command)
            {
                case 'N':
                    return Direction.North;
                case 'E':
                    return Direction.East;
                case 'W':
                    return Direction.West;
                case 'S':
                    return Direction.South;
                default:
                    return Direction.Empty;
            }
        }

        private bool Validate()
        {
            if (_position.X < 0 && _position.Y < 0)
            {
                //throw new InvalidDeployment();
            }
            
            return true;
        }

    }
}

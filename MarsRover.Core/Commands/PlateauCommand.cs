using System;

namespace MarsRover.Core.Commands
{
    public class PlateauCommand : ICommand, IPlateauCommand
    {
        public string Command { get; set; }
        private IPlateauGrid _plateauGrid;

        public PlateauCommand(IPlateauGrid plateauGrid)
        {
            _plateauGrid = plateauGrid;
        }

        public void Initialize(string command)
        {
            Command = command;
        }

        public void Process()
        {
            string[] commandParams = Command.Split(' ');
            _plateauGrid.SetPlateauGrid(Int32.Parse(commandParams[0]), Int32.Parse(commandParams[1]));
        }

        public IPlateauGrid GetPlateau()
        {
            return _plateauGrid;
        }

    }
}

namespace MarsRover.Core.Commands
{
    public class MoveCommand : ICommand, IMoveCommand
    {
        public string Command { get; set; }
        IRoverAction _roverAction;
        IRover _rover;
        IPlateauGrid _plateauGrid;

        public MoveCommand(IRoverAction roverAction)
        {
            _roverAction = roverAction;
        }

        public void Initialize(IRover rover, string command, IPlateauGrid plateauGrid)
        {
            _rover = rover;
            _plateauGrid = plateauGrid;
            _roverAction.SetRoverToPlateau(_plateauGrid, _rover);
            Command = command;
        }


        public void Process()
        { 
            foreach (char commandItem in Command.Trim())
            {
                if (commandItem == 'L')
                {
                    _roverAction.Move(ActionType.TurnLeft);
                }
                else if (commandItem == 'R')
                {
                    _roverAction.Move(ActionType.TurnRight);
                }
                else if (commandItem == 'M')
                {
                    _roverAction.Move(ActionType.Move);
                }
            }
        }

    }
}

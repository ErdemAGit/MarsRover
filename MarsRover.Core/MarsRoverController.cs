using System;
using System.Text;
using MarsRover.Core.Commands;
using System.IO;

namespace MarsRover.Core
{
    public class MarsRoverController : IMarsRoverController
    {
        IPlateauGrid _plateauGrid;
        IRover _rover;

        private readonly IPlateauCommand _plateauCommand;
        private readonly IDeployRoverCommand _deployRoverCommand;
        private readonly IMoveCommand _moveCommand;
        public MarsRoverController(IPlateauCommand plateauCommand, IDeployRoverCommand deployRoverCommand, IMoveCommand moveCommand)
        {
            _plateauCommand = plateauCommand;
            _deployRoverCommand = deployRoverCommand;
            _moveCommand = moveCommand;

        }


        public string ExecuteCommand(string command)
        {
            var result = new StringBuilder();

            using (StringReader commandReader = new StringReader(command))
            {
                string commandline;
                int index = 0;
                
                while ((commandline = commandReader.ReadLine()) != null)
                {
              
                    if (index == 0)
                    {
                        //First command for set plateua
                        SetPlateau(commandline);
                    }
                    else if (index % 2 == 1)
                    {
                        //After first command, first of every two commands is deploy command
                        DeployRover(commandline);
                    }
                    else if (index % 2 == 0)
                    {
                        //After first command, second of every two commands is move command
                        MoveRover(commandline);
                        result.AppendLine(String.Format("{0} {1} {2}", _rover.Position.X, _rover.Position.Y, _rover.Position.Direction.ToString()[0]));
                    }
                   
                    index++;
                }
            }

            return result.ToString();
        }

        public void SetPlateau(string commandline)
        {
            _plateauCommand.Initialize(commandline);
            _plateauCommand.Process();
            _plateauGrid = _plateauCommand.GetPlateau();
        }

        public void DeployRover(string commandline)
        {
            _deployRoverCommand.Initialize(_plateauGrid, commandline);
            _deployRoverCommand.Process();
            _rover = _deployRoverCommand.GetRover();
        }

        public void MoveRover(string commandline)
        {
            _moveCommand.Initialize(_rover, commandline, _plateauGrid);
            _moveCommand.Process();
        }
    }
}

using MarsRover.Core.Exceptions;

namespace MarsRover.Core
{
    public class RoverAction : IRoverAction
    {
        IPlateauGrid _plateauGrid;
        IRover _rover;

        public void SetRoverToPlateau(IPlateauGrid plateauGrid, IRover rover)
        {
            _plateauGrid = plateauGrid;
            _rover = rover;
        }

        public void Move(ActionType actionType)
        {
            IPosition currentPosition = _rover.Position;

            if (actionType == ActionType.Move)
            {
                switch (_rover.Position.Direction)
                {
                    case Direction.North:
                        currentPosition.Y++;
                        break;
                    case Direction.East:
                        currentPosition.X++;
                        break;
                    case Direction.South:
                        currentPosition.Y--;
                        break;
                    case Direction.West:
                        currentPosition.X--;
                        break;
                }
            }
            else if (actionType == ActionType.TurnLeft)
            {
                switch (_rover.Position.Direction)
                {
                    case Direction.North:
                        currentPosition.Direction = Direction.West;
                        break;
                    case Direction.East:
                        currentPosition.Direction = Direction.North;
                        break;
                    case Direction.South:
                        currentPosition.Direction = Direction.East;
                        break;
                    case Direction.West:
                        currentPosition.Direction = Direction.South;
                        break;
                }
            }
            else if (actionType == ActionType.TurnRight)
            {
                switch (_rover.Position.Direction)
                {
                    case Direction.North:
                        currentPosition.Direction = Direction.East;
                        break;
                    case Direction.East:
                        currentPosition.Direction = Direction.South;
                        break;
                    case Direction.South:
                        currentPosition.Direction = Direction.West;
                        break;
                    case Direction.West:
                        currentPosition.Direction = Direction.North;
                        break;
                }
            }

            Validate(currentPosition);
            _rover.Position = currentPosition;

        }

        private void Validate(IPosition newPosition)
        {
            if (newPosition.X < 0 && newPosition.Y < 0)
            {
                throw new InvalidCommand(ErrorMessages.CanNotNegative);
            }

            if (newPosition.X > _plateauGrid.GridX && newPosition.Y > _plateauGrid.GridY)
            {
                throw new InvalidCommand(ErrorMessages.OutOfPlateau);
            }
        }
    }
}

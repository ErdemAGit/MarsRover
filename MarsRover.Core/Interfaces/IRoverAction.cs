namespace MarsRover.Core
{
    public interface IRoverAction
    {
        void SetRoverToPlateau(IPlateauGrid plateauGrid, IRover rover);

        void Move(ActionType actionType);

    }
}
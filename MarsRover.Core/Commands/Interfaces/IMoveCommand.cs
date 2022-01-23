namespace MarsRover.Core.Commands
{
    public interface IMoveCommand
    {
        string Command { get; set; }

        void Initialize(IRover rover, string command, IPlateauGrid plateauGrid);

        void Process();

    }
}

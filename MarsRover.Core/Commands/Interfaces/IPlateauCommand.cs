namespace MarsRover.Core.Commands
{
    public interface IPlateauCommand
    {
        string Command { get; set; }

        void Initialize(string command);

        void Process();

        IPlateauGrid GetPlateau();
    }
}

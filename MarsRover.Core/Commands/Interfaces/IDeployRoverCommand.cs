namespace MarsRover.Core.Commands
{
    public interface IDeployRoverCommand
    {
        string Command { get; set; }

        void Initialize(IPlateauGrid plateauGrid, string command);

        public void Process();

        public IRover GetRover();

    }
}

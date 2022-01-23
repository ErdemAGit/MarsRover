namespace MarsRover.Core.Commands
{
    public interface ICommand
    {
        string Command { get; set; }
        void Process();
    }
}

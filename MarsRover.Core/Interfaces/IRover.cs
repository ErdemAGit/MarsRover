namespace MarsRover.Core
{
    public interface IRover
    {
        IPosition Position { get; set; }

        void Deploy(IPosition position);

    }
}

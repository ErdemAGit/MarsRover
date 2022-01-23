namespace MarsRover.Core
{
    public class Rover : IRover
    {
        public IPosition Position { get; set; }

        public void Deploy(IPosition position)
        {
            Position = position;
        }
    }
}

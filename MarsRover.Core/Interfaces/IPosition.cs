namespace MarsRover.Core
{
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
        Direction Direction { get; set; }

        void SetPosition(int x, int y, Direction direction);
    }
}

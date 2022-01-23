namespace MarsRover.Core
{
    public interface IPlateauGrid
    {
        int GridX { get; set; }
        int GridY { get; set; }

        void SetPlateauGrid(int gridX, int gridY);

    }
}

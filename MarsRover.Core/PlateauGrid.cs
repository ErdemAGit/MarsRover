using MarsRover.Core.Exceptions;

namespace MarsRover.Core
{
    public class PlateauGrid : IPlateauGrid
    {
        public int GridX { get; set; }
        public int GridY { get; set; }

        public void SetPlateauGrid(int gridX, int gridY)
        {
            GridX = gridX;
            GridY = gridY;
            PlateauValidation();
        }

        private void PlateauValidation()
        {
            if (GridX < 0 || GridY < 0)
            {
               throw new InvalidCommand();
            }
        }
    }
}

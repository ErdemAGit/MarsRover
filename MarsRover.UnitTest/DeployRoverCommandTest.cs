using NUnit.Framework;
using MarsRover.Core;
using MarsRover.Core.Commands;

namespace MarsRover.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeployRoverSuccess()
        {
            Rover rover = new Rover();
            PlateauGrid plateauGrid = new PlateauGrid();
            plateauGrid.SetPlateauGrid(5, 5);
            Position position = new Position();
            DeployRoverCommand deployRoverCommand = new DeployRoverCommand(rover, position);
            deployRoverCommand.Initialize(plateauGrid, "1 2 N");
            deployRoverCommand.Process();
            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(Direction.North, rover.Position.Direction);
        }
    }
}
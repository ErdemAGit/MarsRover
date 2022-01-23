using MarsRover.Core;
using MarsRover.Core.Commands;
using MarsRover.Core.Exceptions;
using NUnit.Framework;

namespace MarsRover.UnitTest
{
    public class PlateauCommandTest
    {

        [Test]
        [TestCase(5, 5, "5 5")]
        [TestCase(100, 100, "100 100")]
        public void SetPlateauSuccess(int x, int y, string command)
        {
            PlateauGrid plateauGrid = new PlateauGrid();
            PlateauCommand setPlateauCommand = new PlateauCommand(plateauGrid);
            setPlateauCommand.Initialize(command);
            setPlateauCommand.Process();
            Assert.AreEqual(x, plateauGrid.GridX);
            Assert.AreEqual(y, plateauGrid.GridY);
        }


        [Test]
        [TestCase("-5 5")]
        [TestCase("5 -5")]
        public void SetPlateau_ThrowsInvalidCommandException(string command)
        {
            PlateauGrid plateauGrid = new PlateauGrid();
            PlateauCommand setPlateauCommand = new PlateauCommand(plateauGrid);
            setPlateauCommand.Initialize(command);
            Assert.Catch<InvalidCommand>(() => setPlateauCommand.Process());
        }

    }
}
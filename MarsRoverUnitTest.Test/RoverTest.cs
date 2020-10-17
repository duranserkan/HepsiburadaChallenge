using MarsRover.Business.Manager;
using MarsRover.Helper;
using System;
using System.Linq;
using Xunit;

namespace MarsRoverUnitTest.Test
{
    public class RoverTest
    {
        private readonly RoverManager _roverManager;
        public RoverTest()
        {
            _roverManager = new RoverManager();
        }

        [Theory]
        [InlineData("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [InlineData("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void StartRoverDiscovery_Discovery_ReturnLastCoordinate(string maximumXYProgress, string startPosition, string advance, string expected)
        {
            var maximumProgress = maximumXYProgress.Trim().Split(' ').Select(int.Parse).ToList();
            var startPositions = startPosition.Trim().Split(' ');

            if (startPositions.Count() == 3)
            {
                _roverManager.X = Convert.ToInt32(startPositions[0]);
                _roverManager.Y = Convert.ToInt32(startPositions[1]);
                _roverManager.Direction = (DirectionType)Enum.Parse(typeof(DirectionType), startPositions[2]);
            }

            _roverManager.StartRoverDiscovery(maximumProgress, advance);

            var actualCoordinate = $"{_roverManager.X} { _roverManager.Y} {_roverManager.Direction}";

            Assert.Equal(expected, actualCoordinate);
        }
    }
}

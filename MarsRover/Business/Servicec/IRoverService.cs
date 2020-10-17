using MarsRover.Helper;
using System.Collections.Generic;

namespace MarsRover.Business.Servicec
{
    public interface IRoverService
    {
        /// <summary>
        /// X Position
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Y Position
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// Direction Type
        /// </summary>
        public DirectionType Direction { get; set; }

        /// <summary>
        /// Rotates the Rover tool 90 degrees to the right or left according to the letter sequence entered, advancing 1 grid in the last direction. 'L--Left, 'R--Right' 'M--Next'.
        /// </summary>
        /// <param name="maximumProgress"></param>
        /// <param name="advance"></param>
        void StartRoverDiscovery(List<int> maximumProgress, string advance);
    }
}

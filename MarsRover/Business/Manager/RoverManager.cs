using MarsRover.Business.Services;
using MarsRover.Helper;
using System;
using System.Collections.Generic;

namespace MarsRover.Business.Manager
{
    public class RoverManager : IRoverService
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionType Direction { get; set; }


        /// <inheritdoc cref="StartRoverDiscovery"/>
        public void StartRoverDiscovery(List<int> maximumProgress, string advance)
        {
            foreach (var move in advance)
            {
                switch (move)
                {
                    case 'M':
                        AdvanceSameDirection();
                        break;
                    case 'L':
                        Direction = Direction.Rotate90DegreesLeft();
                        break;
                    case 'R':
                        Direction = Direction.Rotate90DegreesRight();
                        break;
                    default:
                        Console.WriteLine($"Invalid character {move}");
                        break;
                }

                if (X < 0 || X > maximumProgress[0] || Y < 0 || Y > maximumProgress[1])
                {
                    throw new Exception($"The area to be visited is outside of the determined values. Maximum value entered ({maximumProgress[0]} , {maximumProgress[1]})");
                }
            }
        }

        private void AdvanceSameDirection()
        {
            switch (Direction)
            {
                case DirectionType.N:
                    Y += 1;
                    break;
                case DirectionType.S:
                    Y -= 1;
                    break;
                case DirectionType.E:
                    X += 1;
                    break;
                case DirectionType.W:
                    X -= 1;
                    break;
                default:
                    break;
            }
        }
    }
}

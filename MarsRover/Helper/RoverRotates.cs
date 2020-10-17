namespace MarsRover.Helper
{
    public static class RoverRotates
    {
        public static DirectionType Rotate90DegreesLeft(this DirectionType directionType)
        {
            return directionType switch
            {
                DirectionType.N => DirectionType.W,
                DirectionType.S => DirectionType.E,
                DirectionType.E => DirectionType.N,
                DirectionType.W => DirectionType.S,
                _ => directionType,
            };
        }

        public static DirectionType Rotate90DegreesRight(this DirectionType directionType)
        {
            return directionType switch
            {
                DirectionType.N => DirectionType.E,
                DirectionType.S => DirectionType.W,
                DirectionType.E => DirectionType.S,
                DirectionType.W => DirectionType.N,
                _ => directionType,
            };
        }
    }
}

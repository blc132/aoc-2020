namespace day12
{
    public class Ship
    {
        public int EastPosition { get; set; }
        public int NorthPosition { get; set; }

        public int EastWayPointPosition { get; set; } = 10;
        public int NorthWayPointPosition { get; set; } = 1;

        public DIRECTION Direction { get; set; }
        public int Degrees { get; set; }

        public void MovePart2(string command)
        {
            char type = command[0];
            int value = int.Parse(command.Substring(1));
            int tempEastPosition = EastWayPointPosition;
            int tempNorthPosition = NorthWayPointPosition;

            switch (type)
            {
                case 'N':
                    NorthWayPointPosition += value;
                    break;
                case 'S':
                    NorthWayPointPosition -= value;
                    break;
                case 'E':
                    EastWayPointPosition += value;
                    break;
                case 'W':
                    EastWayPointPosition -= value;
                    break;
                case 'R':
                    switch (value)
                    {
                        case 90:
                            EastWayPointPosition = tempNorthPosition;
                            NorthWayPointPosition = -tempEastPosition;
                            break;
                        case 180:
                            EastWayPointPosition = -tempEastPosition;
                            NorthWayPointPosition = -tempNorthPosition;
                            break;
                        case 270:
                            EastWayPointPosition = -tempNorthPosition;
                            NorthWayPointPosition = tempEastPosition;
                            break;
                    }
                    break;
                case 'L':
                    switch (value)
                    {
                        case 270:
                            EastWayPointPosition = tempNorthPosition;
                            NorthWayPointPosition = -tempEastPosition;
                            break;
                        case 180:
                            EastWayPointPosition = -tempEastPosition;
                            NorthWayPointPosition = -tempNorthPosition;
                            break;
                        case 90:
                            EastWayPointPosition = -tempNorthPosition;
                            NorthWayPointPosition = tempEastPosition;
                            break;
                    }
                    break;
                case 'F':
                    EastPosition += EastWayPointPosition * value;
                    NorthPosition += NorthWayPointPosition * value;
                    break;
            }
        }

        public void MovePart1(string command)
        {
            char type = command[0];
            int value = int.Parse(command.Substring(1));

            switch (type)
            {
                case 'N':
                    NorthPosition += value;
                    break;
                case 'S':
                    NorthPosition -= value;
                    break;
                case 'E':
                    EastPosition += value;
                    break;
                case 'W':
                    EastPosition -= value;
                    break;
                case 'R':
                    Degrees += value;
                    if (Degrees >= 360)
                        Degrees -= 360;
                    SetDirection();
                    break;
                case 'L':
                    Degrees -= value;
                    if (Degrees < 0)
                        Degrees += 360;
                    SetDirection();
                    break;
                case 'F':
                    MoveForward(value);
                    break;
            }
        }

        private void SetDirection()
        {
            switch (Degrees)
            {
                case 0:
                    Direction = DIRECTION.EAST;
                    break;
                case 90:
                    Direction = DIRECTION.SOUTH;
                    break;
                case 180:
                    Direction = DIRECTION.WEST;
                    break;
                case 270:
                    Direction = DIRECTION.NORTH;
                    break;
            }
        }

        private void MoveForward(int value)
        {
            switch (Direction)
            {
                case DIRECTION.EAST:
                    EastPosition += value;
                    break;
                case DIRECTION.WEST:
                    EastPosition -= value;
                    break;
                case DIRECTION.NORTH:
                    NorthPosition += value;
                    break;
                case DIRECTION.SOUTH:
                    NorthPosition -= value;
                    break;
            }
        }
    }

    public enum DIRECTION
    {
        EAST = 0,
        SOUTH = 90,
        WEST = 180,
        NORTH = 270
    }
}

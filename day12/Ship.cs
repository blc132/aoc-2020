namespace day12
{
    public class Ship
    {
        public int EastPosition { get; set; }
        public int NorthPosition { get; set; }
        public DIRECTION Direction { get; set; }
        public int Degrees { get; set; }

        public void Move(string command)
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

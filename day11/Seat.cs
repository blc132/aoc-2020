using System.Collections.Generic;
using System.Drawing;

namespace day11
{
    public class Seat
    {
        public Seat(char state, int x, int y)
        {
            State = state;
            PreviousState = state;
            Cords = new Point(x, y);
        }

        public char PreviousState { get; set; }
        public char State { get; set; }
        public Point Cords { get; set; }
        public List<Seat> AdjacentSeats{ get; set; }
    }
}

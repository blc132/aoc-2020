using System.Collections.Generic;
using System.Drawing;

namespace day11
{
    public class Seat
    {
        public Seat(char state, int x, int y)
        {
            AdjacentSeats = new List<Seat>();
            State = state;
            X = x;
            Y = y;
            PreviousState = state;
            // Cords = new Point(x, y);
        }

        public int X { get; set; }
        public int Y { get; set; }
        public char PreviousState { get; set; }
        public char State { get; set; }
        // public Point Cords { get; set; }
        public List<Seat> AdjacentSeats{ get; set; }
    }
}

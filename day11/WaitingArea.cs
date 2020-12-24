using System;
using System.Collections.Generic;
using System.Linq;

namespace day11
{
    class WaitingArea
    {
        public WaitingArea()
        {
            Seats = new List<Seat>();
        }

        public List<Seat> Seats { get; set; }

        public void SetSeats(string[] lines)
        {
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var type = line[j];
                    if(type == '.')
                        continue;
                    Seats.Add(new Seat(type, j, i));
                }
            }
        }

        public void FillAllSeats()
        {
            foreach (var seat in Seats)
            {
                seat.State = '#';
            }
        }

        public bool NextRound()
        {
            bool stateChanged = false;

            for (int i = 0; i < Seats.Count; i++)
            {
                var adjacentSeats = CountAdjacentSeats(Seats[i]);
                if (adjacentSeats >= 4)
                    Seats[i].State = 'L';
                else if (adjacentSeats == 0)
                    Seats[i].State = '#';

                if (Seats[i].State != Seats[i].PreviousState)
                {
                    stateChanged = true;
                }
            }

            for (int i = 0; i < Seats.Count; i++)
            {
                Seats[i].PreviousState = Seats[i].State;
            }

            return stateChanged;
        }

        public int CountOccupiedSeats()
        {
            return Seats.Count(x => x.State == '#');
        }

        public void SetAllAdjacentSeats()
        {
            foreach (var seat in Seats)
            {
                SetAdjacentSeats(seat);
            }
        }

        private void SetAdjacentSeats(Seat seat)
        {
            int x = seat.Cords.X;
            int y = seat.Cords.Y;

            var adjacentSeats = Seats.Where(s => s.Cords.X == x - 1 && s.Cords.Y == y - 1 ||
                                                  s.Cords.X == x - 1 && s.Cords.Y == y ||
                                                  s.Cords.X == x - 1 && s.Cords.Y == y + 1 ||
                                                  s.Cords.X == x && s.Cords.Y == y + 1 ||
                                                  s.Cords.X == x && s.Cords.Y == y - 1 ||
                                                  s.Cords.X == x + 1 && s.Cords.Y == y - 1 ||
                                                  s.Cords.X == x + 1 && s.Cords.Y == y ||
                                                  s.Cords.X == x + 1 && s.Cords.Y == y + 1)
                .ToList();

            seat.AdjacentSeats = adjacentSeats;
        }

        private int CountAdjacentSeats(Seat seat)
        {
            var adjacentSeats = seat.AdjacentSeats.Count(x => x.PreviousState == '#');
            return adjacentSeats;
        }
    }
}

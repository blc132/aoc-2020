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

        public bool NextRound()
        {
            bool stateChanged = false;

            for (int i = 0; i < Seats.Count; i++)
            {
                var adjacentSeats = CountAdjacentSeats(Seats[i]);
                if (adjacentSeats >= 5)
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
                // SetAdjacentSeatsForPart1(seat);
                SetAdjacentSeatsForPart2(seat);
            }
        }

        private void SetAdjacentSeatsForPart1(Seat seat)
        {
            int x = seat.X;
            int y = seat.Y;

            var adjacentSeats = Seats.Where(s => s.X == x - 1 && s.Y == y - 1 ||
                                                  s.X == x - 1 && s.Y == y ||
                                                  s.X == x - 1 && s.Y == y + 1 ||
                                                  s.X == x && s.Y == y + 1 ||
                                                  s.X == x && s.Y == y - 1 ||
                                                  s.X == x + 1 && s.Y == y - 1 ||
                                                  s.X == x + 1 && s.Y == y ||
                                                  s.X == x + 1 && s.Y == y + 1)
                .ToList();

            seat.AdjacentSeats = adjacentSeats;
        }

        private void SetAdjacentSeatsForPart2(Seat seat)
        {
            int x = seat.X;
            int y = seat.Y;
            int yMax = Seats.Max(x => x.Y);
            int xMax = Seats.Max(x => x.X);
            int counter = xMax >= yMax ? xMax : yMax;


            bool rightUp = false, leftUp = false, leftDown = false, rightDown = false, up = false, left = false, down = false, right = false;

            for (int i = 1; i < counter; i++)
            {
                Seat tempSeat;

                if (!rightUp)
                {
                    tempSeat = Seats.FirstOrDefault(s => s.X == x + i && s.Y == y + i);

                    if (tempSeat != null)
                    {
                        rightUp = true;
                        seat.AdjacentSeats.Add(tempSeat);
                    }
                }

                if (!leftUp)
                {
                    tempSeat = Seats.FirstOrDefault(s => s.X == x - i && s.Y == y + i);

                    if (tempSeat != null)
                    {
                        leftUp = true;
                        seat.AdjacentSeats.Add(tempSeat);
                    }
                }

                if (!leftDown)
                {
                    tempSeat = Seats.FirstOrDefault(s => s.X == x - i && s.Y == y - i);

                    if (tempSeat != null)
                    {
                        leftDown = true;
                        seat.AdjacentSeats.Add(tempSeat);
                    }
                }

                if (!rightDown)
                {
                    tempSeat = Seats.FirstOrDefault(s => s.X == x + i && s.Y == y - i);

                    if (tempSeat != null)
                    {
                        rightDown = true;
                        seat.AdjacentSeats.Add(tempSeat);
                    }
                }

                if (!up)
                {
                    tempSeat = Seats.FirstOrDefault(s => s.X == x && s.Y == y + i);

                    if (tempSeat != null)
                    {
                        up = true;
                        seat.AdjacentSeats.Add(tempSeat);
                    }
                }

                if (!left)
                {
                    tempSeat = Seats.FirstOrDefault(s => s.X == x - i && s.Y == y);

                    if (tempSeat != null)
                    {
                        left = true;
                        seat.AdjacentSeats.Add(tempSeat);
                    }
                }

                if (!down)
                {
                    tempSeat = Seats.FirstOrDefault(s => s.X == x && s.Y == y - i);

                    if (tempSeat != null)
                    {
                        down = true;
                        seat.AdjacentSeats.Add(tempSeat);
                    }
                }

                if (!right)
                {
                    tempSeat = Seats.FirstOrDefault(s => s.X == x + i && s.Y == y);

                    if (tempSeat != null)
                    {
                        right = true;
                        seat.AdjacentSeats.Add(tempSeat);
                    }
                }
            }

        }

        private int CountAdjacentSeats(Seat seat)
        {
            var adjacentSeats = seat.AdjacentSeats.Count(x => x.PreviousState == '#');
            return adjacentSeats;
        }
    }
}

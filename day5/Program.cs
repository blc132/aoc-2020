using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace day5
{
    class Program
    {
        static int GetHighestSeat(string[] lines)
        {
            int highestSeatId = 0;

            foreach (var line in lines)
            {
                int seatId = GetSeatId(line);

                if (seatId > highestSeatId)
                    highestSeatId = seatId;
            }

            return highestSeatId;
        }

        static int GetSeatId(string line)
        {
            string row = line.Substring(0, 7);
            string col = line.Substring(line.Length - 3);

            int colValue = GetValue(col, 'R');
            int rowValue = GetValue(row, 'B');

            int seatId = rowValue * 8 + colValue;

            return seatId;
        }

        static int GetValue(string stringValue, char one)
        {
            int value = 0;
            int stringValueLength = stringValue.Length;

            for (int i = 0; i < stringValue.Length; i++)
            {
                if (stringValue[i] == one)
                    value += IntPow(2, stringValueLength - 1 - i);
            }

            return value;
        }

        static int IntPow(int x, int pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }

        static void DumbWayToGetMissingValues(string[] lines)
        {
            var ch1 = new[] {'B', 'F'};
            var ch2 = new[] {'R', 'L'};

            var emptySeats = new List<int>();

            foreach (var x1 in ch1)
            {
                foreach (var x2 in ch1)
                {
                    foreach (var x3 in ch1)
                    {
                        foreach (var x4 in ch1)
                        {
                            foreach (var x5 in ch1)
                            {
                                foreach (var x6 in ch1)
                                {
                                    foreach (var x7 in ch1)
                                    {
                                        foreach (var y1 in ch2)
                                        {
                                            foreach (var y2 in ch2)
                                            {
                                                foreach (var y3 in ch2)
                                                {
                                                    var seat = $"{x1}{x2}{x3}{x4}{x5}{x6}{x7}{y1}{y2}{y3}";

                                                    if (lines.All(x => x != seat))
                                                    {
                                                        int seatId = GetSeatId(seat);
                                                        emptySeats.Add(seatId);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            emptySeats = emptySeats.OrderBy(x => x).ToList();

            for (int i = 0; i < emptySeats.Count; i++)
            {
                if (i - 1 >= 0 && i + 1 <= emptySeats.Count - 1)
                {
                    int previousSeat = emptySeats[i - 1];
                    int nextSeat = emptySeats[i + 1];
                    int seat = emptySeats[i];

                    if (previousSeat + 1 != seat || nextSeat - 1 != seat)
                        Console.WriteLine(seat);
                }
            }

        }

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            DumbWayToGetMissingValues(lines);
            // Console.WriteLine(GetHighestSeat(lines));
        }
    }
}

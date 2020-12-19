using System;
using System.IO;

namespace day5
{
    class Program
    {
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

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            int highestSeatId = 0;

            foreach (var line in lines)
            {
                string row = line.Substring(0, 7);
                string col = line.Substring(line.Length - 3);

                int colValue = GetValue(col, 'R');
                int rowValue = GetValue(row, 'B');

                int seatId = rowValue * 8 + colValue;

                if (seatId > highestSeatId)
                    highestSeatId = seatId;
            }

            Console.WriteLine(highestSeatId);
        }
    }
}

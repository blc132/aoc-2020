using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.VisualBasic;

namespace day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            int preambleLength = 25;
            int nextNumber;
            List<int> preamble;

            for (int i = 4; i < lines.Length; i++)
            {

                preamble = lines.Skip(i).Take(preambleLength).Select(int.Parse).ToList();
                nextNumber = int.Parse(lines.Skip(i + preambleLength).First());


                var correct = CheckNumber(preamble, nextNumber);

                if (!correct)
                    break;
            }
        }


        public static bool CheckNumber(List<int> preamble, int number)
        {
            for (int i = 0; i < preamble.Count; i++)
            {
                for (int j = 0; j < preamble.Count; j++)
                {
                    if (i == j)
                        continue;

                    if (preamble[i] + preamble[j] == number)
                        return true;

                }
            }
            return false;
        }
    }
}

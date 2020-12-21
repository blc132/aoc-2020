using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Numerics;

using Microsoft.VisualBasic;

namespace day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var invalidNumber = Part1(lines);
            var encryptionWeakness = Part2(lines, invalidNumber);

        }

        private static BigInteger Part2(string[] lines, BigInteger invalidNumber)
        {
            var contiguousSet = new List<BigInteger>();
            var contiguousSetLongest = new List<BigInteger>();

            for (int i = 0; i < lines.Length; i++)
            {
                BigInteger sum = new BigInteger(0);
                for (int j = i; j < lines.Length; j++)
                {
                    var currentNumber = BigInteger.Parse(lines[j]);
                    sum += currentNumber;

                    contiguousSet.Add(currentNumber);


                    if (sum == invalidNumber)
                    {
                        if (contiguousSetLongest.Count < contiguousSet.Count)
                            contiguousSetLongest = contiguousSet.ConvertAll(x => x);

                        contiguousSet.Clear();
                        break;
                    }

                    if (sum > invalidNumber)
                    {
                        contiguousSet.Clear();
                        break;
                    }
                }
            }

            contiguousSetLongest.Sort();

            return contiguousSetLongest.First() + contiguousSetLongest.Last();
        }


        public static BigInteger Part1(string[] lines)
        {

            int preambleLength = 25;
            BigInteger nextNumber = 0;
            List<BigInteger> preamble;

            for (int i = 4; i < lines.Length; i++)
            {
                if (i + preambleLength >= lines.Length)
                    break;

                preamble = lines.Skip(i).Take(preambleLength).Select(BigInteger.Parse).ToList();
                nextNumber = BigInteger.Parse(lines.Skip(i + preambleLength).First());


                var correct = CheckNumber(preamble, nextNumber);

                if (!correct)
                    break;
            }

            return nextNumber;
        }

        public static bool CheckNumber(List<BigInteger> preamble, BigInteger number)
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

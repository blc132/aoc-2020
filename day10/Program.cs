using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace day10
{
    class Program
    {
        static ListOfIntsComparer comparer = new ListOfIntsComparer();

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var adapters = GetAdapters(lines);
            Part1(adapters);
            Part2(adapters);
        }

        static List<int> GetAdapters(string[] lines)
        {
            var adapters = lines.Select(int.Parse).ToList();
            adapters.Sort();

            int outlet = 0;
            int device = adapters.Last() + 3;

            adapters.Add(outlet);
            adapters.Add(device);
            adapters.Sort();
            return adapters;
        }

        static void Part1(List<int> adapters)
        {
            int oneJoltsLower = 0;
            int threeJoltsLower = 0;
            int previousAdapter = adapters[0];


            for (int i = 1; i < adapters.Count; i++)
            {
                if (adapters[i] - previousAdapter == 1)
                    oneJoltsLower++;
                if (adapters[i] - previousAdapter == 3)
                    threeJoltsLower++;

                previousAdapter = adapters[i];
            }
            Console.WriteLine(oneJoltsLower * threeJoltsLower);
        }

        static void Part2(List<int> adapters)
        {
            var solvedSubProblems = new List<List<int>>();
            var groups = new List<List<int>>();
            var tempGroup = new List<int>();

            for (int i = 0; i < adapters.Count; i++)
            {
                if (i == 0)
                    tempGroup.Add(adapters[i]);
                else if (adapters[i] - adapters[i - 1] == 3)
                {
                    groups.Add(tempGroup);
                    tempGroup = new List<int>();
                    tempGroup.Add(adapters[i]);
                }
                else
                    tempGroup.Add(adapters[i]);

            }
            groups.Add(tempGroup);

            long counter = 1;
            foreach (var group in groups)
            {
                CountPossibilities(group, solvedSubProblems);
                counter *= solvedSubProblems.Count;

                solvedSubProblems = new List<List<int>>();
            }

            Console.WriteLine(counter);
        }

        static void CountPossibilities(List<int> adapters, List<List<int>> solvedSubProblems)
        {
            solvedSubProblems.Add(adapters);
            CalculateReq(adapters, solvedSubProblems);
        }

        static void CalculateReq(List<int> adapters, List<List<int>> solvedSubProblems)
        {
            for (int i = 1; i < adapters.Count - 1; i++)
            {
                var nestedAdapters = adapters
                    .Where((t, j) => j != i)
                    .ToList();

                if (nestedAdapters[i] - nestedAdapters[i - 1] > 3)
                    continue;

                if (!solvedSubProblems.Contains(nestedAdapters, comparer))
                    solvedSubProblems.Add(nestedAdapters);

                CalculateReq(nestedAdapters, solvedSubProblems);
            }
        }

        public class ListOfIntsComparer : IEqualityComparer<List<int>>
        {
            public bool Equals(List<int> x, List<int> y)
            {
                return x.SequenceEqual(y);
            }

            public int GetHashCode(List<int> obj)
            {
                int hashCode = 0;

                for (var index = 0; index < obj.Count; index++)
                {
                    hashCode ^= new { Index = index, Item = obj[index] }.GetHashCode();
                }

                return hashCode;
            }
        }
    }
}

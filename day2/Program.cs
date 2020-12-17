using System;
using System.IO;
using System.Linq;

namespace day2
{
    class Program
    {
        public static void PartOne(string[] lines)
        {

            var validCounter = 0;

            foreach (var line in lines)
            {
                var decodedLine = line.Split(' ');

                var range = decodedLine[0].Split('-');
                var start = int.Parse(range[0]);
                var end = int.Parse(range[1]);

                var letter = decodedLine[1][0];

                var password = decodedLine[2];

                var lettersInPassword = password.Count(x => x == letter);

                if (lettersInPassword >= start && lettersInPassword <= end)
                    validCounter++;
            }

            Console.WriteLine(validCounter);
        }

        public static void PartTwo(string[] lines)
        {

            var validCounter = 0;

            foreach (var line in lines)
            {
                var decodedLine = line.Split(' ');

                var range = decodedLine[0].Split('-');
                var index1 = int.Parse(range[0]);
                var index2 = int.Parse(range[1]);

                var letter = decodedLine[1][0];

                var password = decodedLine[2];

                var valid = CalculateValidPassword(password, letter, index1, index2);

                if (valid)
                    validCounter += 1;
            }

            Console.WriteLine(validCounter);
        }

        public static bool CalculateValidPassword(string password, char letter, int index1, int index2)
        {
            var validLetters = false;

            for (var i = 0; i < password.Length; i++)
            {
                if (password[i] != letter || i + 1 != index1 && i + 1 != index2)
                    continue;
                if (validLetters)
                    return false;
                validLetters = true;
            }

            return validLetters;
        }


        static void Main(string[] args)
        {
            var lines  = File.ReadAllLines("input.txt");

            PartTwo(lines);
        }
    }
}

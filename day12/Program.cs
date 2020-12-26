using System;
using System.IO;

namespace day12
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var ship = new Ship();

            foreach (var command in lines)
            {
                    ship.Move(command);
            }

            Console.WriteLine(Math.Abs(ship.EastPosition) + Math.Abs(ship.NorthPosition));
        }
    }
}

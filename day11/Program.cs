using System.IO;

namespace day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var waitingArea = new WaitingArea();

            waitingArea.SetSeats(lines);
            waitingArea.SetAllAdjacentSeats();

            bool stateChanged = true;

            while (stateChanged)
            {
                stateChanged = waitingArea.NextRound();
            }

            int result = waitingArea.CountOccupiedSeats();
        }
    }
}

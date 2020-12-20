using System.IO;

namespace day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var bootCode = new BootCode(lines);

            bootCode.RunCode();

            var acc = bootCode.Accumulator;
        }
    }
}

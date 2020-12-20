using System.IO;

namespace day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var bootCode = new BootCode(lines);


            for (int i = 0; i < lines.Length; i++)
            {
                if (bootCode.Instructions[i].Type != INSTRUCTION_TYPE.ACC)
                {
                    bootCode.CleanExecutions();
                    bootCode.SwapInstruction(i);
                    bootCode.RunCode();
                    bootCode.SwapInstruction(i);

                    if (bootCode.Terminates)
                        break;
                }
            }

            var acc = bootCode.Accumulator;
        }
    }
}

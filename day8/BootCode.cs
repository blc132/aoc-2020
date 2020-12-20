using System.Collections.Generic;

namespace day8
{
    public class BootCode
    {
        public int Accumulator { get; set; }
        public bool Terminates { get; set; }
        public List<Instruction> Instructions { get; set; }

        public BootCode(string[] lines)
        {
            Instructions = new List<Instruction>();
            for (int i = 0; i < lines.Length; i++)
            {
                Instructions.Add(new Instruction(lines[i], i + 1));
            }
        }

        public void SwapInstruction(int index)
        {
            var instr = Instructions[index];

            switch (instr.Type)
            {
                case INSTRUCTION_TYPE.JMP:
                    instr.Type = INSTRUCTION_TYPE.NOP;
                    break;
                case INSTRUCTION_TYPE.NOP:
                    instr.Type = INSTRUCTION_TYPE.JMP;
                    break;
            }
        }

        public void CleanExecutions()
        {
            Accumulator = 0;
            foreach (var instruction in Instructions)
            {
                instruction.Executed = false;
            }
        }

        public void RunCode()
        {
            for (int i = 0; i < Instructions.Count; i++)
            {
                var instr = Instructions[i];

                if (instr.Executed)
                    return;
                instr.Executed = true;

                switch (instr.Type)
                {
                    case INSTRUCTION_TYPE.ACC:
                        Accumulator += instr.Value;
                        break;
                    case INSTRUCTION_TYPE.JMP:
                        i += instr.Value - 1;
                        break;
                }

                if (i == Instructions.Count - 1)
                {
                    Terminates = true;
                    return;
                }
            }
        }
    }
}

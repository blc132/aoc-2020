using System.Collections.Generic;

namespace day8
{
    public class BootCode
    {
        public int Accumulator { get; set; }
        public List<Instruction> Instructions { get; set; }

        public BootCode(string[] lines)
        {
            Instructions = new List<Instruction>();
            for (int i = 0; i < lines.Length; i++)
            {
                Instructions.Add(new Instruction(lines[i], i + 1));
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
            }
        }
    }
}

namespace day8
{
    public class Instruction
    {
        public Instruction(string line, int lineOfCode)
        {
            var values = line.Split(' ');
            Type = values[0] switch
            {
                "acc" => INSTRUCTION_TYPE.ACC,
                "jmp" => INSTRUCTION_TYPE.JMP,
                "nop" => INSTRUCTION_TYPE.NOP,
                _ => Type
            };

            Value = int.Parse(values[1].Replace("+", ""));
            LineOfCode = lineOfCode;
        }

        public INSTRUCTION_TYPE Type { get; set; }
        public int Value { get; set; }
        public int LineOfCode { get; set; }
        public bool Executed { get; set; }
    }

    public enum INSTRUCTION_TYPE
    {
        ACC,
        JMP,
        NOP,
    }
}

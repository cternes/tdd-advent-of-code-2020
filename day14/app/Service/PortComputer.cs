namespace app.Service
{
    using System.Collections.Generic;
    using Model;

    public class PortComputer
    {
        private readonly Dictionary<int, long> memory = new Dictionary<int, long>();
        private string mask;

        public long ProcessInput(List<string> inputList)
        {
            foreach (var input in inputList)
            {
                var instruction = new Instruction(input);
                if (instruction.Operation == OperationType.Mask)
                {
                    mask = instruction.MaskValue;
                }
                else if (instruction.Operation == OperationType.StoreMemory)
                {
                    var parameter = new DockingParameter(instruction.MemoryStorageValue.Value, mask);
                    memory[instruction.MemoryStorageValue.Address] = parameter.ApplyMask();
                }
            }

            return CalculateSum();
        }

        private long CalculateSum()
        {
            long sum = 0;
            foreach (var value in memory.Values)
            {
                sum += value;
            }

            return sum;
        }
    }
}
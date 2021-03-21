namespace app.Model
{
    public class Instruction
    {
        public OperationType Operation { get; set; }

        public string MaskValue { get; set; }

        public MemoryStorage MemoryStorageValue { get; set; }

        public Instruction(string input)
        {
            var splitted = input.Split("=");

            if (splitted[0].Trim() == "mask")
            {
                InitMask(splitted);
            }
            else
            {
                InitMemory(splitted);
            }
        }

        private void InitMemory(string[] splitted)
        {
            Operation = OperationType.StoreMemory;

            var address = int.Parse(splitted[0].Replace("mem[", "").Replace("]", ""));
            var value = int.Parse(splitted[1]);

            MemoryStorageValue = new MemoryStorage(address, value);
        }

        private void InitMask(string[] splitted)
        {
            Operation = OperationType.Mask;
            MaskValue = splitted[1].Trim();
        }
    }
}
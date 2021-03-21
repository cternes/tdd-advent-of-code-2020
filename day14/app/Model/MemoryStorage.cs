namespace app.Model
{
    public class MemoryStorage
    {
        public int Address { get; }

        public int Value { get; }

        public MemoryStorage(int address, int value)
        {
            Address = address;
            Value = value;
        }
    }
}
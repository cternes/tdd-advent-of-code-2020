namespace app.Model
{
    using System;

    public class DockingParameter
    {
        public int Value { get; }

        public string Mask { get; }

        public DockingParameter(int value, string mask)
        {
            Value = value;
            Mask = mask;
        }

        public long ApplyMask()
        {
            var bits = ConvertValueToBitRepresentation();
            var maskedBits = UseMask(bits);
            
            return ConvertBitsToInteger(maskedBits);
        }

        private long ConvertBitsToInteger(char[] bits)
        {
            var newValue = new string(bits);
            return Convert.ToInt64(newValue, 2);
        }

        private char[] UseMask(char[] bits)
        {
            for (var i = 0; i < Mask.Length; i++)
            {
                if (Mask[i] == 'X')
                {
                    continue;
                }

                bits[i] = Mask[i];
            }

            return bits;
        }

        private char[] ConvertValueToBitRepresentation()
        {
            return Convert.ToString(Value, 2).PadLeft(36, '0').ToCharArray();
        }
    }
}
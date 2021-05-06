namespace day5.Model
{
    public class Node
    {
        public readonly Range Data;

        public Node Left { get; set; }
        
        public Node Right { get; set; }
        
        public bool Visited { get; set; }

        public Node(int min, int max) 
            : this(new Range(min, max))
        {
        }

        public Node(Range data)
        {
            Data = data;

            var range = Data.Max - Data.Min;
            if (NextLevelIsRange(range))
            {
                var left = new Node(Data.Min, Data.Min + range / 2);
                Left = left;

                var right = new Node(Data.Min + range / 2 + 1, Data.Max);
                Right = right;
            }

            if (NextLevelIsLeaf(range))
            {
                Left = new Node(Data.Min, data.Min);
                Right = new Node(Data.Max, data.Max);
            }
        }

        private static bool NextLevelIsLeaf(int range)
        {
            return range == 1;
        }

        private static bool NextLevelIsRange(int range)
        {
            return range > 2;
        }
    }
}
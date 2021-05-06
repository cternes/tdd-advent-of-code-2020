namespace day7.Model
{
    using System.Collections.Generic;

    public class Bag
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public List<Bag> Children { get; set; } = new List<Bag>();
        
        public bool IsOuterBag { get; set; }
    }
}
namespace app.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;
    using Parser;

    public class RuleService
    {
        private readonly RuleInterpreter interpreter = new RuleInterpreter();
        private readonly List<Bag> bags;

        public RuleService(List<string> rules)
        {
            bags = interpreter.InterpretRules(rules);
        }

        public int GetNumberOfOuterBags(string bagColor)
        {
            var outerBags = new HashSet<Bag>();
            var bagsThatHoldColor = bags
                .Where(i => HasChildrenWithColor(i.Children, bagColor))
                .ToList();

            bagsThatHoldColor.ForEach(i => outerBags.Add(i));

            return GetOuterBagsForColor(bagsThatHoldColor, outerBags);
        }

        private int GetOuterBagsForColor(List<Bag> bagsThatHoldColor, HashSet<Bag> outerBags)
        {
            foreach (var bag in bagsThatHoldColor)
            {
                var possibleParents = bags
                    .Where(i => HasChildrenWithColor(i.Children, bag.Name))
                    .ToList();

                possibleParents.ForEach(i => outerBags.Add(i));
                
                if(possibleParents.Any())
                {
                    GetOuterBagsForColor(possibleParents, outerBags);
                }
            }

            return outerBags.Count;
        }

        private bool HasChildrenWithColor(List<Bag> bagList, string color)
        {
            return bagList.Where(i => i.Name == color)
                .ToList()
                .Any();
        }
    }
}
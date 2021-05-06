namespace day7.Parser
{
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class RuleInterpreter
    {
        private readonly RuleParser parser = new RuleParser();
        private readonly Dictionary<string, Bag> bags = new Dictionary<string, Bag>();

        public List<Bag> InterpretRules(List<string> rules)
        {
            rules
                .Select(RuleToBag)
                .ToList()
                .ForEach(RegisterBag);

            return GetBagList();
        }

        private void RegisterBag(Bag bag)
        {
            var existingBag = bags.SingleOrDefault(i => i.Key == bag.Name);

            if (existingBag.Key == null)
            {
                bags.Add(bag.Name, bag);
                RegisterChildBags(bag);
            }
            else
            {
                var missingChilds = bag.Children.Except(existingBag.Value.Children).ToList();
                existingBag.Value.Children.AddRange(missingChilds);
            }
        }

        private void RegisterChildBags(Bag bag)
        {
            bag.Children.ForEach(RegisterBag);
        }

        private Bag RuleToBag(string rule)
        {
            return parser.ParseRule(rule);
        }

        private List<Bag> GetBagList()
        {
            return bags.Select(i => i.Value).ToList();
        }
    }
}
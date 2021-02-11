namespace app.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class RuleParser
    {
        public Bag ParseRule(string rule)
        {
            var parts = rule.Split("contain");
            var parent = ParseParent(parts);
            parent.Children = ParseChildren(parts);

            return parent;
        }

        private static Bag ParseParent(string[] parts)
        {
            return new Bag
            {
                Name = SanitizeName(parts[0]),
                IsOuterBag = true
            };
        }

        private List<Bag> ParseChildren(string[] parts)
        {
            var bagParts = parts[1].Split(",");

            if (ContainsNoOtherBags(parts[1]))
            {
                return new List<Bag>();
            }

            return FetchChildren(bagParts);
        }

        private static List<Bag> FetchChildren(string[] bagParts)
        {
            return bagParts
                .Select(i => i.Trim())    
                .Select(i => new Bag
                {
                    Quantity = int.Parse(i[0].ToString()),
                    Name = SanitizeName(i[1..])
                }).ToList();
        }

        private bool ContainsNoOtherBags(string value)
        {
            return SanitizeName(value).Equals("no other", StringComparison.InvariantCultureIgnoreCase);
        }

        private static string SanitizeName(string value)
        {
            return value.Replace("bags", "")
                .Replace("bag", "")
                .Replace(".", "")
                .Trim();
        }
    }
}
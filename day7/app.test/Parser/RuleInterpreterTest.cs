namespace app.test.Parser
{
    using System.Collections.Generic;
    using System.Linq;
    using app.Parser;
    using FluentAssertions;
    using Xunit;

    public class RuleInterpreterTest
    {
        [Fact]
        public void ShouldWork()
        {
            // Arrange
            var rules = new List<string>
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags."
            };
            var interpreter = new RuleInterpreter();

            // Act
            var bags = interpreter.InterpretRules(rules);

            // Assert
            var redBag = bags.Single(i => i.Name == "light red");
            var yellowBag = redBag.Children.Single(i => i.Name == "muted yellow");
            
            yellowBag.Children.Should().Contain(i => i.Name == "shiny gold");
            yellowBag.Children.Should().Contain(i => i.Name == "faded blue");
        }
    }
}
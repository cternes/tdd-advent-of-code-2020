namespace day7.test.Parser
{
    using day7.Parser;
    using FluentAssertions;
    using Xunit;

    public class RuleParserTest
    {
        [Theory]
        [InlineData("light red bags contain 1 bright white bag, 2 muted yellow bags.", "light red", 1, "bright white", 2, "muted yellow")]
        [InlineData("dark orange bags contain 3 bright white bags, 4 muted yellow bags.", "dark orange", 3, "bright white", 4, "muted yellow")]
        [InlineData("muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.", "muted yellow", 2, "shiny gold", 9, "faded blue")]
        public void ShouldParseRule(string rule, 
            string expectedParent,
            int expectedQuantityFirstChild,
            string expectedFirstChild,
            int expectedQuantitySecondChild,
            string expectedSecondChild)
        {
            // Arrange
            var ruleParser = new RuleParser();

            // Act
            var bag = ruleParser.ParseRule(rule);

            // Assert
            bag.Name.Should().Be(expectedParent);
            bag.Children[0].Quantity.Should().Be(expectedQuantityFirstChild);
            bag.Children[0].Name.Should().Be(expectedFirstChild);

            bag.Children[1].Quantity.Should().Be(expectedQuantitySecondChild);
            bag.Children[1].Name.Should().Be(expectedSecondChild);
        }

        [Fact]
        public void ShouldReturnBagWithoutChildren()
        {
            // Arrange
            var rule = "faded blue bags contain no other bags.";
            var ruleParser = new RuleParser();

            // Act
            var bag = ruleParser.ParseRule(rule);

            // Assert
            bag.Name.Should().Be("faded blue");
            bag.Children.Should().HaveCount(0);
        }
    }
}
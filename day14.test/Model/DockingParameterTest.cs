namespace day14.test.Model
{
    using day14.Model;
    using FluentAssertions;
    using Xunit;

    public class DockingParameterTest
    {

        [Fact]
        public void ShouldApplyMask()
        {
            // Arrange
            var parameter = new DockingParameter(11, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");
            
            // Act
            var res = parameter.ApplyMask();

            // Assert
            res.Should().Be(73);
        }
    }
}
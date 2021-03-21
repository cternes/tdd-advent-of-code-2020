namespace app.test.Service
{
    using System.Collections.Generic;
    using app.Service;
    using FluentAssertions;
    using Xunit;

    public class PortComputerTest
    {
        [Fact]
        public void ShouldProcessInput()
        {
            // Arrange
            var input = new List<string>
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mem[8] = 0"
            };

            var pc = new PortComputer();

            // Act
            var res = pc.ProcessInput(input);

            // Assert
            res.Should().Be(165);
        }
    }
}
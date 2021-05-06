namespace day14.test.Model
{
    using day14.Model;
    using FluentAssertions;
    using Xunit;

    public class InstructionTest
    {
        [Fact]
        public void ShouldParseMaskInstruction()
        {
            // Act
            var instruction = new Instruction("mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");

            // Assert
            instruction.Operation.Should().Be(OperationType.Mask);
            instruction.MaskValue.Should().Be("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");
        }

        [Fact]
        public void ShouldParseStoreMemoryInstruction()
        {
            // Act
            var instruction = new Instruction("mem[8] = 11");
            
            // Assert
            instruction.Operation.Should().Be(OperationType.StoreMemory);
            instruction.MemoryStorageValue.Address.Should().Be(8);
            instruction.MemoryStorageValue.Value.Should().Be(11);
        }
    }
}
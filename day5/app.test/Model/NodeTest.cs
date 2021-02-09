namespace app.test.Model
{
    using app.Model;
    using FluentAssertions;
    using Xunit;

    public class NodeTest
    {
        [Fact]
        public void ShouldGetRootNode()
        {
            // Arrange
            // Act
            var root = new Node(new Range(0, 11));

            // Assert
            root.Data.Min.Should().Be(0);
            root.Data.Max.Should().Be(11);
        }
        
        [Fact]
        public void ShouldFillLeftNode()
        {
            // Arrange
            // Act
            var root = new Node(new Range(0, 11));

            // Assert
            root.Left.Data.Min.Should().Be(0);
            root.Left.Data.Max.Should().Be(5);
        }

        [Fact]
        public void ShouldFillRightNode()
        {
            // Arrange
            // Act
            var root = new Node(new Range(0, 11));

            // Assert
            root.Right.Data.Min.Should().Be(6);
            root.Right.Data.Max.Should().Be(11);
        }

        [Fact]
        public void ShouldFillRightBranch()
        {
            // Arrange
            // Act
            var root = new Node(new Range(0, 11));

            // Assert
            var rootNode = root;
            rootNode.Right.Data.Min.Should().Be(6);
            rootNode.Right.Data.Max.Should().Be(11);

            rootNode.Right.Right.Data.Min.Should().Be(9);
            rootNode.Right.Right.Data.Max.Should().Be(11);
        }

        [Fact]
        public void ShouldFillLeftBranch()
        {
            // Arrange
            // Act
            var root = new Node(new Range(0, 11));

            // Assert
            var rootNode = root;
            rootNode.Left.Data.Min.Should().Be(0);
            rootNode.Left.Data.Max.Should().Be(5);

            rootNode.Left.Left.Data.Min.Should().Be(0);
            rootNode.Left.Left.Data.Max.Should().Be(2);
        }


        [Fact]
        public void ShouldReturnLeaf()
        {
            // Arrange
            // Act
            var root = new Node(new Range(5, 6));

            // Assert
            var rootNode = root;
            rootNode.Left.Data.Min.Should().Be(5);
            rootNode.Left.Data.Max.Should().Be(5);

            rootNode.Right.Data.Min.Should().Be(6);
            rootNode.Right.Data.Max.Should().Be(6);
        }

    }
}
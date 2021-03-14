namespace app.test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class AdapterTest
    {
        [Fact]
        public void ShouldGetBuiltInAdapterRating()
        {
            // Arrange
            var adapters = AdaptersInBag();

            // Act
            var rating = new BuiltInAdapter(adapters).GetRate();


            // Assert
            rating.Should().Be(22);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 4)]
        [InlineData(4, 5)]
        [InlineData(5, 6)]
        [InlineData(6, 7)]
        [InlineData(7, 10)]
        [InlineData(10, 11)]
        [InlineData(11, 12)]
        [InlineData(12, 15)]
        [InlineData(15, 16)]
        [InlineData(16, 19)]
        public void ShouldFindNextAdapterWhichCanConnect(int output, int expectedAdapter)
        {
            // Arrange
            var adapters = AdaptersInBag();

            // Act
            var rating = new BuiltInAdapter(adapters).FindNextAdapter(output);

            // Assert
            rating.Should().Be(expectedAdapter);
        }

        [Fact]
        public void ShouldFindAdapterWhichCanConnectDirectly()
        {
            // Arrange
            var adapters = new List<int>
            {
                16,
                1,
                15,
                0
            };

            // Act
            var rating = new BuiltInAdapter(adapters).FindFirstMatchingAdapter(0);

            // Assert
            rating.Should().Be(0);
        }

        [Fact]
        public void ShouldFindAdapterWhichCanConnectWith1JoltDifference()
        {
            // Arrange
            var adapters = new List<int>
            {
                16,
                1,
                15
            };

            // Act
            var rating = new BuiltInAdapter(adapters).FindFirstMatchingAdapter(0);

            // Assert
            rating.Should().Be(1);
        }

        [Fact]
        public void ShouldFindAdapterWhichCanConnectWith2JoltDifference()
        {
            // Arrange
            var adapters = new List<int>
            {
                16,
                2,
                15
            };

            // Act
            var rating = new BuiltInAdapter(adapters).FindFirstMatchingAdapter(0);

            // Assert
            rating.Should().Be(2);
        }

        [Fact]
        public void ShouldFindAdapterWhichCanConnectWith3JoltDifference()
        {
            // Arrange
            var adapters = new List<int>
            {
                16,
                3,
                15
            };

            // Act
            var rating = new BuiltInAdapter(adapters).FindFirstMatchingAdapter(0);

            // Assert
            rating.Should().Be(3);
        }

        private static List<int> AdaptersInBag()
        {
            return new()
            {
                16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };
        }
    }

    public class BuiltInAdapter
    {
        private readonly List<int> adapters;

        public BuiltInAdapter(List<int> adapters)
        {
            this.adapters = adapters;
        }

        public int GetRate()
        {
            return adapters.Max() + 3;
        }

        public int FindFirstMatchingAdapter(int output)
        {
            for (var i = 0; i < 4; i++)
            {
                var matchingAdapter = HasMatchingAdapter(output + i);
                if (matchingAdapter != null) return (int) matchingAdapter;
            }

            throw new NotSupportedException("Could not find matching adapter");
        }

        public int FindNextAdapter(int output)
        {
            for (var i = 1; i < 4; i++)
            {
                var matchingAdapter = HasMatchingAdapter(output + i);
                if (matchingAdapter != null) return (int) matchingAdapter;
            }
            
            throw new NotSupportedException("Could not find matching adapter");
        }

        private int? HasMatchingAdapter(int output)
        {
            try
            {
                return adapters.First(i => i == output);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}
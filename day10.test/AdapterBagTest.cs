namespace day10.test
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Service;
    using Xunit;

    public class AdapterBagTest
    {
        [Fact]
        public void ShouldGetBuiltInAdapterRating()
        {
            // Arrange
            var adapters = AdaptersInBag();

            // Act
            var rating = new AdapterBag(adapters).GetBuiltInAdapterRate();


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
            var rating = new AdapterBag(adapters).FindNextAdapter(output);

            // Assert
            rating.Should().Be(expectedAdapter);
        }


        [Fact]
        public void ShouldCountNumberOfJoltDifferences()
        {
            // Arrange
            var adapters = AdaptersInBag();
            var adapterBag = new AdapterBag(adapters);

            // Act
            adapterBag.CheckAllAdapters();

            // Assert
            adapterBag.NumberOf1JoltDifferences.Should().Be(7);
            adapterBag.NumberOf3JoltDifferences.Should().Be(5);
        }

        [Fact]
        public void ShouldCountNumberOfJoltDifferencesWithBiggerExample()
        {
            // Arrange
            var adapters = new List<int>
            {
                28,
                33,
                18,
                42,
                31,
                14,
                46,
                20,
                48,
                47,
                24,
                23,
                49,
                45,
                19,
                38,
                39,
                11,
                1,
                32,
                25,
                35,
                8,
                17,
                7,
                9,
                4,
                2,
                34,
                10,
                3,
            };
            var adapterBag = new AdapterBag(adapters);

            // Act
            adapterBag.CheckAllAdapters();

            // Assert
            adapterBag.NumberOf1JoltDifferences.Should().Be(22);
            adapterBag.NumberOf3JoltDifferences.Should().Be(10);
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
            var rating = new AdapterBag(adapters).FindFirstMatchingAdapter(0);

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
            var rating = new AdapterBag(adapters).FindFirstMatchingAdapter(0);

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
            var rating = new AdapterBag(adapters).FindFirstMatchingAdapter(0);

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
            var rating = new AdapterBag(adapters).FindFirstMatchingAdapter(0);

            // Assert
            rating.Should().Be(3);
        }

        [Fact]
        public void ShouldReturnNumberOf1JoltDifferences()
        {
            // Arrange
            var adapters = AdaptersInBag();

            var adapterBag = new AdapterBag(adapters);
            
            // Act
            adapterBag.FindFirstMatchingAdapter(0);
            adapterBag.FindNextAdapter(4);
            
            // Assert
            adapterBag.NumberOf1JoltDifferences.Should().Be(2);
        }

        [Fact]
        public void ShouldReturnNumberOf3JoltDifferences()
        {
            // Arrange
            var adapters = AdaptersInBag();

            var adapterBag = new AdapterBag(adapters);
            
            // Act
            adapterBag.FindNextAdapter(1);
            adapterBag.FindNextAdapter(7);

            
            // Assert
            adapterBag.NumberOf3JoltDifferences.Should().Be(2);
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
}
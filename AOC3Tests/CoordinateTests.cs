using AOC3;
using FluentAssertions;
using Xunit;

namespace AOC3Tests
{
    public class CoordinateTests
    {
        [Fact]
        public void CalculateCorrectManhattanCenter()
        {
            var coordinate = new Coordinate
            {
                X = 3,
                Y = 3
            };
            coordinate.ManhattanDistanceToCenter().Should().Be(6);

            coordinate.X = -3;
            coordinate.Y = 3;
            coordinate.ManhattanDistanceToCenter().Should().Be(6);
        }
    }
}
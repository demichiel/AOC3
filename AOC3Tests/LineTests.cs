using System.Collections.Generic;
using System.Linq;
using AOC3;
using FluentAssertions;
using Xunit;

namespace AOC3Tests
{
    public class LineTests
    {
        [Fact]
        public void ShouldGenerateCorrectPath()
        {
            var movements = new List<Movement>()
            {
                new Movement
                {
                    Direction = Direction.Right,
                    Steps = 8
                },
                new Movement
                {
                    Direction = Direction.Up,
                    Steps = 5
                },
                new Movement
                {
                    Direction = Direction.Left,
                    Steps = 5
                },
                new Movement
                {
                    Direction = Direction.Down,
                    Steps = 3
                },
            };
            var line = new Line(movements);
            line.Path.Last().Should().BeEquivalentTo(new Coordinate
            {
                X = 3,
                Y = 2
            });
        }

        [Fact]
        public void ShouldFindCorrectIntersections()
        {
            var line1 = new Line(new List<Movement>()
            {
                new Movement
                {
                    Direction = Direction.Right,
                    Steps = 8
                },
                new Movement
                {
                    Direction = Direction.Up,
                    Steps = 5
                },
                new Movement
                {
                    Direction = Direction.Left,
                    Steps = 5
                },
                new Movement
                {
                    Direction = Direction.Down,
                    Steps = 3
                },
            });
            var line2 = new Line(new List<Movement>()
            {
                new Movement
                {
                    Direction = Direction.Up,
                    Steps = 7
                },
                new Movement
                {
                    Direction = Direction.Right,
                    Steps = 6
                },
                new Movement
                {
                    Direction = Direction.Down,
                    Steps = 4
                },
                new Movement
                {
                    Direction = Direction.Left,
                    Steps = 4
                },
            });

            var intersections = line1.FindIntersections(line2);

            intersections.Should().BeEquivalentTo(new List<Coordinate>
            {
                new Coordinate
                {
                    X = 3,
                    Y = 3
                },
                new Coordinate
                {
                    X = 6,
                    Y = 5
                },
            });

            var shortestManhattanDistance = intersections.Min(c => c.ManhattanDistanceToCenter());
            shortestManhattanDistance.Should().Be(6);
        }
    }
}
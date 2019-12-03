using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC3
{
    public class Line
    {
        public List<Coordinate> Path { get; set; }

        public Line(List<Movement> movements)
        {
            Path = new List<Coordinate>
            {
                new Coordinate
                {
                    X = 0,
                    Y = 0
                }
            };
            foreach (var movement in movements)
            {
                switch (movement.Direction)
                {
                    case Direction.Up:
                        for (int i = 0; i < movement.Steps; i++)
                        {
                            Path.Add(new Coordinate
                            {
                                X = Path.Last().X,
                                Y = Path.Last().Y + 1
                            });
                        }
                        break;
                    case Direction.Right:
                        for (int i = 0; i < movement.Steps; i++)
                        {
                            Path.Add(new Coordinate
                            {
                                X = Path.Last().X + 1,
                                Y = Path.Last().Y
                            });
                        }
                        break;
                    case Direction.Down:
                        for (int i = 0; i < movement.Steps; i++)
                        {
                            Path.Add(new Coordinate
                            {
                                X = Path.Last().X,
                                Y = Path.Last().Y - 1
                            });
                        }
                        break;
                    case Direction.Left:
                        for (int i = 0; i < movement.Steps; i++)
                        {
                            Path.Add(new Coordinate
                            {
                                X = Path.Last().X - 1,
                                Y = Path.Last().Y
                            });
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public List<Coordinate> FindIntersections(Line otherLine)
        {
            return Path.Intersect(otherLine.Path).Where(c => !(c.X == 0 && c.Y == 0)).ToList();
        }
    }
}
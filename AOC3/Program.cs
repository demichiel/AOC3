using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace AOC3
{
    class Program
    {
        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines("C:\\Users\\Michiel\\source\\repos\\AdventOfCode\\AOC3\\AOC3\\input");

            SolvePartOne(allLines);
            SolvePartTwo(allLines);
        }

        private static void SolvePartOne(string[] allLines)
        {
            var line1 = new Line(ParseLineToMovements(allLines[0]));
            var line2 = new Line(ParseLineToMovements(allLines[1]));

            var intersections = line1.FindIntersections(line2);

            var lowestDistance = intersections.Min(c => c.ManhattanDistanceToCenter());

            Console.WriteLine(lowestDistance);
        }

        private static void SolvePartTwo(string[] allLines)
        {
            var line1 = new Line(ParseLineToMovements(allLines[0]));
            var line2 = new Line(ParseLineToMovements(allLines[1]));

            var intersections = line1.FindIntersections(line2);

            var sum = 0;
            foreach (var intersection in intersections)
            {
                var stepsLine1 = line1.Path.IndexOf(intersection);
                var stepsLine2 = line2.Path.IndexOf(intersection);
                var currentSum = stepsLine1 + stepsLine2;
                if (sum == 0 || currentSum < sum)
                {
                    sum = currentSum;
                }
            }

            Console.WriteLine(sum);
        }

        static List<Movement> ParseLineToMovements(string line)
        {
            var result = new List<Movement>();
            var movementsInText = line.Split(",");
            foreach (var movement in movementsInText)
            {
                switch (movement[0])
                {
                    case 'U':
                        result.Add(new Movement
                        {
                            Direction = Direction.Up,
                            Steps = int.Parse(movement.Substring(1))
                        });
                        break;
                    case 'R':
                        result.Add(new Movement
                        {
                            Direction = Direction.Right,
                            Steps = int.Parse(movement.Substring(1))
                        });
                        break;
                    case 'D':
                        result.Add(new Movement
                        {
                            Direction = Direction.Down,
                            Steps = int.Parse(movement.Substring(1))
                        });
                        break;
                    case 'L':
                        result.Add(new Movement
                        {
                            Direction = Direction.Left,
                            Steps = int.Parse(movement.Substring(1))
                        });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return result;
        }
    }
}

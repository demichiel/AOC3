using System;

namespace AOC3
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int ManhattanDistanceToCenter()
        {
            return Math.Abs(X) + Math.Abs(Y);
        }

        public bool Equals(Coordinate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Coordinate) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}
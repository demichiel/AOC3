namespace AOC3
{
    public class Movement
    {
        public Direction Direction { get; set; }
        public int Steps { get; set; }
    }

    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
}
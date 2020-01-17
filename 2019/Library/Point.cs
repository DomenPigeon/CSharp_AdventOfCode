using System;

namespace Library {
    [Serializable]
    public class Point {
        public int  x    { get; }
        public int  y    { get; }
        public char Mark { get; }

        public Point Parent { get; set; }

        public int Manhattan => Math.Abs(x + y);

        public Point(int x, int y, char mark = ' ') {
            this.x = x;
            this.y = y;
            Mark   = mark;
        }

        public bool Equals(Point other) {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj) {
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode() {
            unchecked {
                return (x * 397) ^ y;
            }
        }

        public override string ToString() {
            return $"{Mark} ({x},{y})";
        }

        public static Point Zero  { get; } = new Point(0, 0);
        public static Point One   { get; } = new Point(1, 1);
        public static Point Left  { get; } = new Point(-1, 0);
        public static Point Right { get; } = new Point(1, 0);
        public static Point Up    { get; } = new Point(0, -1);
        public static Point Down  { get; } = new Point(0, 1);

        public static bool operator ==(Point p1, Point p2) {
            return (p1.x == p2.x) && (p1.y == p2.y);
        }

        public static bool operator !=(Point p1, Point p2) {
            return (p1.x != p2.x) || (p1.y != p2.y);
        }

        public static Point operator +(Point p1, Point p2) {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }
        
        public static Point operator -(Point p1, Point p2) {
            return new Point(p1.x - p2.x, p1.y - p2.y);
        }
    }
}
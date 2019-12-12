using System;

namespace AdventLibrary {
    public struct Point {
        public int x { get; }
        public int y { get; }
        public char Mark { get; }

        public int Manhattan => Math.Abs(x + y);

        public Point(int x, int y, char mark = ' ') {
            this.x = x;
            this.y = y;
            Mark = mark;
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

        public static Point Zero { get; } = new Point(0, 0);
        public static Point One { get; } = new Point(1, 1);

        public static bool operator ==(Point p1, Point p2) {
            return (p1.x == p2.x) && (p1.y == p2.y);
        }

        public static bool operator !=(Point p1, Point p2) {
            return (p1.x != p2.x) || (p1.y != p2.y);
        }
    }
}
using System.Collections.Generic;

namespace AdventLibrary {
    public class DiscreteCoordinateSystem {
        public char ClearMark = '.';
        
        private List<Point> _points = new List<Point>();
        private (int left, int right, int top, int down) _size = (0, 0, 0, 0);

        public void AddPoint(Point p) {
            _points.Add(p);
        }

        public void RemovePoint(Point p) {
            _points.Remove(p);
        }

        public char[,] Draw() {
            foreach (var point in _points) {
                UpdateSize(point);
            }
            
            var canvas = new char[_size.left + _size.right + 2, _size.top + _size.down + 2];
            ClearCanvas(canvas);

            foreach (var point in _points) {
                canvas[point.X, point.Y] = point.Mark;
            }
            
            return canvas;
        }

        private void ClearCanvas(char[,] canvas) {
            for (int i = 0; i < canvas.GetLength(0); i++) {
                for (int j = 0; j < canvas.GetLength(1); j++) {
                    canvas[i, j] = ClearMark;
                }
            }
        }

        private void UpdateSize(Point p) {
            if (p.X > _size.right) {
                _size.right = p.X;
            }
            else if (p.X < _size.left) {
                _size.left = p.X * -1;
            }
            
            if (p.Y > _size.top) {
                _size.top = p.Y;
            }
            else if (p.Y < _size.down) {
                _size.down = p.Y * -1;
            }
        }
    }

    public struct Point {
        public int X { get; }
        public int Y { get; }
        public char Mark { get; }

        public Point(int x, int y, char mark = ' ') {
            X = x;
            Y = y;
            Mark = mark;
        }
    }
}
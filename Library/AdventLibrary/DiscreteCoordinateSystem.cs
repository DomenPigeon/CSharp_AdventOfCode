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
                canvas[point.x, point.y] = point.Mark;
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
            if (p.x > _size.right) {
                _size.right = p.x;
            }
            else if (p.x < _size.left) {
                _size.left = p.x * -1;
            }
            
            if (p.y > _size.top) {
                _size.top = p.y;
            }
            else if (p.y < _size.down) {
                _size.down = p.y * -1;
            }
        }
    }
}
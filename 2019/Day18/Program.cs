using System.Collections.Generic;
using Library;

namespace Day18 {
    internal class Program {
        public static void Main(string[] args) {
            var input = ParseInput.ToArray("../../input", ',');

            var map = new char[input.Length, input.Length];
            for (int i = 0; i < input.GetLength(0); i++) {
                var chars = input[i].ToCharArray();
                for (int j = 0; j < chars.Length; j++) {
                    map[j, i] = chars[j];
                }
            }
            
            var keys = new Dictionary<char, Point>();
            for (int x = 0; x < map.GetLength(0); x++) {
                for (int y = 0; y < map.GetLength(1); y++) {
                    var path = map[x, y];
                    if (path >= 'a' && path <= 'z') {
                        keys.Add(path, new Point(x, y, path));
                    }
                }
            }

            var doors = new Dictionary<char, Point>();
            for (int x = 0; x < map.GetLength(0); x++) {
                for (int y = 0; y < map.GetLength(1); y++) {
                    var path = map[x, y];
                    if (path >= 'A' && path <= 'Z') {
                        doors.Add(path, new Point(x, y, path));
                    }
                }
            }


            int StepsToPoint(Point startPos, Point point) {
                var movingP = new Point(startPos.x, startPos.y, startPos.Mark);
                var paths = new List<Point>();
                if (map[point.x, point.y] == '#') return -1;
                
                var lastDir = Point.Right;

                // MoveRight
                while (movingP.x <= map.GetLength(0) && map[movingP.x, movingP.y] == '.') {
                    
                    
                    movingP += Point.Right;
                }

                return 0;
            }
            
        }
    }
}












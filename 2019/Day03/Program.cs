using System;
using System.Drawing.Imaging;
using AdventLibrary;
using Console = AdventLibrary.Console;

namespace Day03 {
    internal class Program {
        private static int[,] Map = new int[500, 500];

        public static void Main(string[] args) {
            var input = ParseInput.ToJaggedArray("../../input", ',');
            var wire1 = input[0];
            var wire2 = input[1];

//            wire1 = "R8,U5,L5,D3".Split(',');
//            wire2 = "U7,R6,D4,L4".Split(',');
//            wire1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72".Split(',');
//            wire2 = "U62,R66,U55,R34,D71,R55,D58,R83".Split(',');
//            wire1 = "R7,D3,R8,U8,L1,D4,R7,U7,L7".Split(',');
//            wire2 = "U6,R6,U5,R3,D7,R5,D5,R8".Split(',');
            wire1 = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51".Split(',');
            wire2 = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7".Split(',');

            var cs1 = LayWire(wire1);
            var cs2 = LayWire(wire2);
//            File.Write2D("map", Map, 2);
//            Console.WriteLine(ClosestCross(500));

//            var cs1 = new DiscreteCoordinateSystem();
//            cs1.AddPoint(new Point(50, 50));
//            cs1.AddPoint(new Point(10, 10));
//            var cs2 = new DiscreteCoordinateSystem();
//            cs2.AddPoint(new Point(10, 10));
//            cs2.AddPoint(new Point(30, 30));

            var pic1 = Canvas.CreateImage(cs1.GetPoints2D(), "red", new []{0,0});
            var a = cs1.Center - cs2.Center;
            var pic2 = Canvas.CreateImage(cs2.GetPoints2D(), "green", new []{a.x,a.y});
            File.Write2D("pic1.txt", cs1.GetPoints2D(), 2);
            File.Write2D("pic2.txt", cs2.GetPoints2D(), 2);
            
            pic1.Save("pic1.png", ImageFormat.Png);
            pic2.Save("pic2.png", ImageFormat.Png);

            var result = Canvas.MultiplyImages(pic1, pic2);
            result.Save("image.png", ImageFormat.Png);

 
            var overlapping = cs1.OverlappingPoints(cs2);
            var closest = int.MaxValue;
            foreach (var point in overlapping) {
                if(point == Point.Zero) continue;
                var distance = point.Manhattan;
                if (distance < closest) closest = distance;
            }
            
            Console.WriteLine(closest);
            Console.WriteLine(cs1.Center);
            Console.WriteLine(cs2.Center);
        }

        private static DiscreteCoordinateSystem LayWire(string[] wireInstructions) {
            var map = new DiscreteCoordinateSystem();
            var mapIndex = (x: 0, y: 0);

            foreach (var instruction in wireInstructions) {
                var distance = (x: 0, y: 0);
                switch (instruction.Substring(0, 1)) {
                    case "R":
                        distance.x = int.Parse(instruction.Substring(1));
                        break;
                    case "L":
                        distance.x = -int.Parse(instruction.Substring(1));
                        break;
                    case "U":
                        distance.y = int.Parse(instruction.Substring(1));
                        break;
                    case "D":
                        distance.y = -int.Parse(instruction.Substring(1));
                        break;
                }

                var startPoint = new Point(mapIndex.x, mapIndex.y, '¤');

                mapIndex.x += distance.x;
                mapIndex.y += distance.y;
                var endPoint = new Point(mapIndex.x, mapIndex.y, '¤');
                map.AddLineOfPoints(startPoint, endPoint);
            }
            
            map.RemovePoint(new Point(0,0,'¤'));

            return map;
        }
    }
}
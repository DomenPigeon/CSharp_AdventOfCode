using System.IO;

namespace AdventLibrary {
    public static class ParseInput {
        public static string[,] ToArray2D(string path, char separator = ' ') {
            var lines = ToArray(path);

            var array2D = new string[MaxCellsInLine(lines), lines.Length];

            for (var i = 0; i < lines.Length; i++) {
                var cells = lines[i].Split(separator);
                for (var j = 0; j < cells.Length; j++) {
                    array2D[j, i] = cells[j].Trim();
                }
            }

            return array2D;

            int MaxCellsInLine(string[] array) {
                var maxCells = 0;

                foreach (var line in array) {
                    var cells = line.Split(separator).Length;
                    if (cells > maxCells) {
                        maxCells = cells;
                    }
                }

                return maxCells;
            }
        }

        public static string[] ToArray(string path) {
            if (File.Exists(path)) {
                return File.ReadAllLines(path);
            }

            return null;
        }

        public static int[] ToInts(this string[] strings) {
            var ints = new int[strings.Length];
            for (var i = 0; i < strings.Length; i++) {
                ints[i] = int.Parse(strings[i]);
            }

            return ints;
        }
        
        public static float[] ToFloats(this string[] strings) {
            var ints = new float[strings.Length];
            for (var i = 0; i < strings.Length; i++) {
                ints[i] = float.Parse(strings[i]);
            }

            return ints;
        }
        
        public static double[] ToDoubles(this string[] strings) {
            var ints = new double[strings.Length];
            for (var i = 0; i < strings.Length; i++) {
                ints[i] = double.Parse(strings[i]);
            }

            return ints;
        }
    }
}
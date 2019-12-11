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
    }
}
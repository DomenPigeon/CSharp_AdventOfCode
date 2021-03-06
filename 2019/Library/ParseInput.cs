using System.Collections.Generic;
using System.IO;

namespace Library {
    public class ParseInput {
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

        public static string[][] ToJaggedArray(string path, char separator = ' ') {
            var lines = ToArray(path);

            var jaggedArray = new string[lines.Length][];

            for (var i = 0; i < lines.Length; i++) {
                var cells = lines[i].Split(separator);
                jaggedArray[i] = new string[cells.Length];
                for (var j = 0; j < cells.Length; j++) {
                    jaggedArray[i][j] = cells[j].Trim();
                }
            }

            return jaggedArray;
        }

        public static string[] ToArray(string pathOrInput, char separator = ' ') {
            var array = new List<string>();
            var lines = File.Exists(pathOrInput) ? File.ReadAllLines(pathOrInput) : pathOrInput.Split(separator);

            foreach (var line in lines) {
                foreach (var cell in line.Split(separator)) {
                    array.Add(cell);
                }
            }

            return array.ToArray();
        }
    }
}
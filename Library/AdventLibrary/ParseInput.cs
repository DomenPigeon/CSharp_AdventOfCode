using System.IO;

namespace AdventLibrary {
    public static class ParseInput {
        public static string[,] ToArray2D(string path, char separator = ' ') {
            var lines = ToArray(path);

            var array2D = new string[lines[0].Split(separator).Length, lines.Length];

            for (var i = 0; i < lines.Length; i++) {
                var cells = lines[i].Split(separator);
                for (var j = 0; j < cells.Length; j++) {
                    array2D[j, i] = cells[j];
                }
            }

            return array2D;
        }

        public static string[] ToArray(string path) {
            string[] array = new string[1];
            if (!File.Exists(path)) {
                File.WriteAllLines(path, array);
            }

            return array;
        }
    }
}
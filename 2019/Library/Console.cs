using System.Text;

namespace Library {
    public class Console {
        public static void WriteLine(object message) {
            System.Console.WriteLine(message);
        }

        public static void WriteLine(string message) {
            System.Console.WriteLine(message);
        }

        public static void WriteLine(params string[] messages) {
            System.Console.WriteLine(messages);
        }

        public static void WriteLine1D<T>(T[] list, int cellWidth = 5) {
            foreach (var cell in list) {
                System.Console.Write(FixStringWidth(cell, cellWidth));
            }
        }

        public static void Write2D<T>(T[,] list, int cellWidth = 3) {
            for (int i = 0; i < list.GetLength(1); i++) {
                System.Console.Write($"y{i,-7}");
                for (int j = 0; j < list.GetLength(0); j++) {
                    if (list[j, i] == null) continue;
                    System.Console.Write(FixStringWidth(list[j, i], cellWidth));
                }

                System.Console.Write('\n');
            }

            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.Write($"{" ",-8}");
            for (int i = 0; i < list.GetLength(0); i++) {
                System.Console.Write(FixStringWidth($"x{i}", cellWidth));
            }
        }
        
        public static void Write2D<T>(T[][] list, int cellWidth = 3) {
            for (int i = 0; i < list.Length; i++) {
                System.Console.Write($"y{i,-7}");
                for (int j = 0; j < list[0].Length; j++) {
                    if (list[i][j] == null) continue;
                    System.Console.Write(FixStringWidth(list[i][j], cellWidth));
                }

                System.Console.Write('\n');
            }

            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.Write($"{" ",-8}");
            for (int i = 0; i < list.GetLength(0); i++) {
                System.Console.Write(FixStringWidth($"x{i}", cellWidth));
            }
        }

        private static string FixStringWidth(object stringObject, int cellWidth = 5, char separator = ' ') {
            var @string = stringObject.ToString();
            if (@string.Length >= cellWidth) return @string;

            var formattedCell = new StringBuilder(@string);
            while (formattedCell.Length < cellWidth) {
                formattedCell.Append(separator);
            }

            return formattedCell.ToString();
        }
    }
}
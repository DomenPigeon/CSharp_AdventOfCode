using System.Text;

namespace AdventLibrary {
    public static class Console {
        public static void WriteLine(object message) {
            System.Console.WriteLine(message);
        }
        public static void WriteLine(string message) {
            System.Console.WriteLine(message);
        }

        public static void WriteLine(params string[] messages) {
            System.Console.WriteLine(messages);
        }

        public static void WriteLine2D<T>(T[,] list, int cellWidth = 3) {
            for (int i = 0; i < list.GetLength(1); i++) {
                System.Console.Write($"y{i, -7}");
                for (int j = 0; j < list.GetLength(0); j++) {
                    if(list[j, i] == null) continue;
                    System.Console.Write(FormatCell(list[j, i].ToString()));
                }

                System.Console.Write('\n');
            }

            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.Write($"{" ", -8}");
            for (int i = 0; i < list.GetLength(0); i++) {
                System.Console.Write(FormatCell($"x{i}"));
            }

            string FormatCell(string cell, char separator = ' ') {
                if (cell.Length >= cellWidth) return cell;

                var formattedCell = new StringBuilder(cell);
                while (formattedCell.Length < cellWidth) {
                    formattedCell.Append(separator);
                }

                return formattedCell.ToString();
            }
        }
    }
}
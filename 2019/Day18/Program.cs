using Library;

namespace Day18 {
    internal class Program {
        public static void Main(string[] args) {
            var input = ParseInput.ToJaggedArray("../../input", ',');
            Console.Write2D(input, 2);
        }
    }
}
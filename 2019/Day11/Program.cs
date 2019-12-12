using AdventLibrary;

namespace Day11 {
    internal class Program {
        public static void Main(string[] args) {
            var input = ParseInput.ToArray2D("input");
            Console.Write2D(input, cellWidth: 9);
        }
    }
}
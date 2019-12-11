using System;
using AdventLibrary;
using Console = AdventLibrary.Console;

namespace Day03 {
    internal class Program {
        public static void Main(string[] args) {
            var input = ParseInput.ToJaggedArray("../../input", ',');
            var wire1 = input[1];
            var wire2 = input[2];
            Console.WriteLine1D(input[0]);
        }
    }
}
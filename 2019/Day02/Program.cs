using System;
using AdventLibrary;
using Console = AdventLibrary.Console;

namespace Day02 {
    internal class Program {
        public static void Main(string[] args) {
            var input = ParseInput.ToArray("../../input", ',').ToInts();
            input[1] = 12;
            input[2] = 2;
//            input = ParseInput.ToArray("1,9,10,3,2,3,11,0,99,30,40,50", ',').ToInts();      // sample 1 
//            input = ParseInput.ToArray("1,0,0,0,99", ',').ToInts();                         // sample 2
//            input = ParseInput.ToArray("2,3,0,3,99", ',').ToInts();                         // sample 3
//            input = ParseInput.ToArray("2,4,4,5,99,0", ',').ToInts();                       // sample 4
//            input = ParseInput.ToArray("1,1,1,4,99,5,6,0,99", ',').ToInts();                // sample 5

            var program = new OpProgram(input);
            for (int i = 0; i < 100; i++) {
                for (int j = 0; j < 100; j++) {
                    input[1] = i;
                    input[2] = j;
                    var result = program.Run(input);
                    if (result == 19690720)
                        goto Finish;
                }
            }

            Finish: 
            Console.WriteLine(100 * input[1] + input[2]);
        }
    }
}
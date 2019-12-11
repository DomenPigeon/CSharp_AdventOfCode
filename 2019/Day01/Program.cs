using System;
using AdventLibrary;
using Console = AdventLibrary.Console;

namespace Day01 {
    internal class Program {
        public static void Main(string[] args) {
            var input = ParseInput.ToArray("input").ToDoubles();
            for (var i = 0; i < input.Length; i++) {
                var fuelForMass = Math.Floor(input[i] / 3) - 2;
                var allFuel = fuelForMass;
                while (fuelForMass > 0) {
                    fuelForMass = Math.Floor(fuelForMass / 3) - 2;
                    allFuel += fuelForMass >= 0 ? fuelForMass : 0;
                }

                input[i] = allFuel;
            }

            var fuel = 0d;
            foreach (var el in input) {
                fuel += el;
            }
            
            Console.WriteLine(fuel);
        }
    }
}
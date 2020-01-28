using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Day04 {
    internal class Program {
        private static Stopwatch _stopwatch = new Stopwatch();

        public static void Main(string[] args) {
            var input = "245318-765747";
            Calculate();
        }


        private static void Calculate() {
            var match = new List<int>();
            for (var i = 245318; i < 765747; i++) {
                if (HasDoubleDigits(i) && DigitsNotDecreasing(i)) {
                    match.Add(i);
                }
            }

            Console.WriteLine(match.Count);

            SecondHalf();

            void SecondHalf() {
                var strictMatch = new List<int>();
                foreach (var m in match) {
                    if (HasExactlyDoubleDigits(m)) {
                        strictMatch.Add(m);
                    }
                }

                Console.WriteLine(strictMatch.Count);
            }
        }

        private static bool DigitsNotDecreasing(int number) {
            var previousDigit = 0;
            var numberString  = number.ToString();
            foreach (var digit in numberString) {
                var d = int.Parse(digit.ToString());
                if (d < previousDigit) return false;
                previousDigit = d;
            }

            return true;
        }

        private static bool HasDoubleDigits(int number) {
            var numberString = number.ToString();
            for (var i = 0; i < numberString.Length; i++) {
                try {
                    if (numberString[i] == numberString[i + 1]) return true;
                }
                catch { }
            }

            return false;
        }

        private static bool HasExactlyDoubleDigits(int number) {
            var numberString = number.ToString();
            for (var i = 0; i < numberString.Length; i++) {
                try {
                    if (numberString[i] == numberString[i + 1]) {
                        try {
                            if (numberString[i] == numberString[i + 2])
                                continue;
                            if (i == 0)
                                return true;
                            if (numberString[i - 1] != numberString[i])
                                return true;
                        }
                        catch {
                            if (numberString[i] == numberString[i + 1] && numberString[i - 1] != numberString[i])
                                return true;
                        }
                    }
                }
                catch { }
            }

            return false;
        }
    }
}
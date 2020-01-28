using System;
using System.Diagnostics;

namespace SpeedTest {
    internal class Program {
        public static void Main(string[] args) {
            var iterations = 1_000_000_000;
            ForLoopTest(iterations);
        }

        private static void ForLoopTest(long iterations) {
            var sw = new Stopwatch();
            sw.Start();
            for(var i=0; i<iterations; i++);
            sw.Stop();
            Console.WriteLine($"For loop had {iterations} iterations and finished in {sw.ElapsedMilliseconds} ms.");
        }
    }
}
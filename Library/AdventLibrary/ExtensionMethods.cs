namespace AdventLibrary {
    public static class ExtensionMethods {
        public static int[] ToInts(this string[] strings) {
            var ints = new int[strings.Length];
            for (var i = 0; i < strings.Length; i++) {
                ints[i] = int.Parse(strings[i]);
            }

            return ints;
        }
        
        public static float[] ToFloats(this string[] strings) {
            var floats = new float[strings.Length];
            for (var i = 0; i < strings.Length; i++) {
                floats[i] = float.Parse(strings[i]);
            }

            return floats;
        }
        
        public static double[] ToDoubles(this string[] strings) {
            var doubles = new double[strings.Length];
            for (var i = 0; i < strings.Length; i++) {
                doubles[i] = double.Parse(strings[i]);
            }

            return doubles;
        }
    }
}
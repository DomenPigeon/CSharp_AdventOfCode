namespace AdventLibrary {
    public static class Console {
        public static void WriteLine(string message) {
            System.Console.WriteLine(message);
        }
        
        public static void WriteLine(params string[] messages) {
            System.Console.WriteLine(messages);
        }

        public static void WriteLine2D<T>(T[,] list) {
            for (int i = 0; i < list.Length; i++) {
                System.Console.Write($"{i, -5}");
                for (int j = 0; j < list.GetLength(1); j++) {
                    System.Console.Write(list[j, i]);
                }
                System.Console.Write('\n');
            }
        }
    }
}
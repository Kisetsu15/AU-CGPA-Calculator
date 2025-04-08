namespace Utils {
    public static class Terminal {

        public static string Input( ConsoleColor color, string message = "" ) {
            Console.ForegroundColor = color;
            Console.Write(message);
            string input = Console.ReadLine()!;
            Console.ResetColor();
            return input;
        }

        public static string Input( string message = "" ) => Input(Console.ForegroundColor, message);

        public static void DisplayMessage( string message, ConsoleColor color ) {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void DisplayError( Exception exception ) => DisplayMessage($"Error: {exception.Message}", ConsoleColor.Red);

    }
}
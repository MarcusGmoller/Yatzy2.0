namespace DieExample
{
    /// <summary>
    /// Contains methods for formatting strings and changing console text color.
    /// </summary>
    public static class Format
    {
        /// <summary>
        /// Changes the console foreground color and writes a string to the console.
        /// The console color is reset after the string is written.
        /// </summary>
        /// <param name="input">The string to write to the console.</param>
        /// <param name="color">The console color to set.</param>
        public static void EasyColour(string input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        /// <summary>
        /// Returns a string consisting of a repeated symbol of a given length.
        /// </summary>
        /// <param name="symbol">The symbol to be repeated.</param>
        /// <param name="length">The length of the resulting string.</param>
        /// <returns>A string of the specified length consisting of repeated symbols.</returns>
        private static string Repeat(char symbol, int length)
        {
            return new string(symbol, length);
        }
        /// <summary>
        /// Returns a string consisting of a symbol and a message separated by spaces and surrounded by spaces of a given length.
        /// </summary>
        /// <param name="symbol">The symbol to be displayed before and after the message.</param>
        /// <param name="length">The total length of the resulting string, including the spaces and the symbol.</param>
        /// <param name="message">The message to be displayed between the symbols.</param>
        /// <returns>A string consisting of a symbol and a message separated by spaces and surrounded by spaces of a given length.</returns>
        public static string Messages(char symbol, int length, string message)
        {
            return symbol + " " + message + " " + Repeat(symbol, length - message.Length - 2);
        }
        /// <summary>
        /// Creates a message box with the given symbol, length and message.
        /// </summary>
        /// <param name="symbol">The symbol to use for the border of the message box.</param>
        /// <param name="length">The length of the message box, including the border and any padding.</param>
        /// <param name="message">The message to display in the message box.</param>
        /// <returns>A string representing the message box.</returns>
        public static string MessageBox(char symbol, int length, string message)
        {
            int spaces = (length - message.Length - 2) / 2;
            string border = Repeat(symbol, length);
            string formattedMessage = symbol + Repeat(' ', spaces) + message + Repeat(' ', spaces) + symbol;
            return border + "\n" + formattedMessage + "\n" + border;

        }
        /// <summary>
        /// Creates a message box using the provided message and a symbol for the border.
        /// The length of the message box is set to 60 characters.
        /// </summary>
        /// <param name="text">The message to be displayed inside the message box.</param>
        /// <returns>A string containing the formatted message box.</returns>
        public static string WriteMessage(string text)
        {
            string message = text;
            string framedMessageBox = Format.MessageBox('#', 60, message);
            return framedMessageBox;
        }

    }
}

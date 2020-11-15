using System;

namespace ServicesLibrary.Helpers
{
    public static class MessageHelper
    {
        public static void Color(string errorMessage, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
            Console.ReadLine();
        }

    }
}

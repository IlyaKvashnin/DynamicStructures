using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.Console
{
    public static class StringExtension
    {
        public static void Center(this string text)
        {
            int width = System.Console.WindowWidth;
            int padding = width / 2 + text.Length / 2;

            System.Console.WriteLine("{0," + padding + "}", text);
        }
    }
    public class ConsoleHelper
    {
        
        public static void CleanScreen()
        {
            for (int i = 0; i < System.Console.WindowHeight; i++)
            {
                System.Console.SetCursorPosition(0, i);
                System.Console.Write(new String(' ', System.Console.WindowWidth));
            }

            System.Console.SetCursorPosition(0, 0);
        }

    }
}

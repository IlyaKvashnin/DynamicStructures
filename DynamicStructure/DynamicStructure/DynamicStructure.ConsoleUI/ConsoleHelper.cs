using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.ConsoleUI
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
        public static string CenterText(string text, int neededLength)
        {
            int missingSpace = neededLength - text.Length;
            return string.Join("", new string(' ', (missingSpace + 1) / 2), text, new string(' ', missingSpace / 2));
        }

        public static void DrawSeparator(int maxLength,int length, char left, char middle, char right)
        {
            Console.Write(left);
            Console.Write(string.Join(middle, Enumerable.Repeat(new string('═', maxLength), length)));
            Console.WriteLine(right);
        }
        public static void ClearScreen()
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

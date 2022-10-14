using DynamicStructure.DynamicStructure.Core.Stack;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.ConsoleUI
{ 
    public class PrintStackLogic
    {
        public static DynamicStructure.Core.Stack.Stack<string> stack = new DynamicStructure.Core.Stack.Stack<string>();
      
        public void PrintStack()
        {
            ConsoleHelper.ClearScreen();
            print();
        }
        public void PrintPush()
        {
            ConsoleHelper.ClearScreen();
            print();
            Console.WriteLine("Введите строку или число, которое нужно положить в стек.");
            var value = Console.ReadLine();
            int num;
            bool isNum = int.TryParse(value, out num);
            if (isNum)
                stack.Push(num.ToString());
            else
                stack.Push(value);
            Console.WriteLine($"Добавлено значение: {value}");
        }

        public void PrintPop()
        {
            ConsoleHelper.ClearScreen();
            if (!stack.IsEmpty())
            {
                var value = stack.Pop();
                Console.WriteLine($"Удалено значение: {value}");
                Console.WriteLine("\n");
                Console.WriteLine("Текущее содержимое стека :");
                print();
            }
            else
            {
                Console.WriteLine("Стек пуст, значение не может быть извлечено.");
            }
        }

        public void PrintTop()
        {
            ConsoleHelper.ClearScreen();
            if (!stack.IsEmpty())
            {
                var value = stack.Top();
                Console.WriteLine($"Вершина стека: {value}");
            Console.WriteLine("\n");
            Console.WriteLine("Текущее содержимое стека :");
                print();
            }
            else
            {
                Console.WriteLine("Стек пуст, вершину невозможно отобразить.");
            }
           
        }

        private void print()
        {
            if (!stack.IsEmpty())
            {
                drawSeparator(1, '╔', '╦', '╗');
                for (int i = -1; i < stack.Count; i++)
                {
                    if (i == 0)
                    {
                        drawSeparator(1, '╠', '╬', '╣');
                    }
                    for (int j = 0; j < 1; j++)
                    {
                        Console.Write('║');
                        if (i == -1)
                        {
                            Console.Write(centerText($"Stack", stack.Max));
                        }
                        else
                        {
                            Console.Write(centerText(stack.ToArray()[i], stack.Max));
                        }
                    }
                    Console.WriteLine('║');
                }
                drawSeparator(1, '╚', '╩', '╝');
            }
            else
            {
                drawSeparator(1, '╔', '╦', '╗');
                Console.Write('║');
                Console.Write(centerText($"Stack", stack.Max));
                Console.WriteLine('║');
                drawSeparator(1, '╚', '╩', '╝');
            }
        }
        static string centerText(string text, int neededLength)
        {
            int missingSpace = neededLength - text.Length;
            return string.Join("", new string(' ', (missingSpace + 1) / 2), text, new string(' ', missingSpace / 2));
        }

        static void drawSeparator(int length, char left, char middle, char right)
        {
            Console.Write(left);
            Console.Write(string.Join(middle, Enumerable.Repeat(new string('═', stack.Max), length)));
            Console.WriteLine(right);
        }
    }
}

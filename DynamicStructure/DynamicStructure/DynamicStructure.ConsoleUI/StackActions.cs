using DynamicStructure.DynamicStructure.Core.Stack;
using DynamicStructure.DynamicStructure.FileWorker;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DynamicStructure.DynamicStructure.ConsoleUI
{
    public class StackActions
    {
        public static DynamicStructure.Core.Stack.Stack<string> stack = new DynamicStructure.Core.Stack.Stack<string>();
        public void PrintStack()
        {
            ConsoleHelper.ClearScreen();


            if (stack.IsEmpty())
            {
                Console.WriteLine("Необходимо добавить элементы в стек.");
                Console.WriteLine("\n");
                return;
            }
            else
            {
                Console.WriteLine("Содержимое стека :");

                ConsoleHelper.DrawSeparator(stack.MaxLengthItems,1, '╔', '╦', '╗');
                for (int i = stack.Count(); i >= 0; i--)
                {
                    if (i == stack.Count() - 1)
                    {
                        ConsoleHelper.DrawSeparator(stack.MaxLengthItems,1, '╠', '╬', '╣');
                    }
                    for (int j = 0; j < 1; j++)
                    {
                        Console.Write('║');
                        if (i == stack.Count())
                        {
                            Console.Write(ConsoleHelper.CenterText($"Stack", stack.MaxLengthItems));
                        }
                        else
                        {
                            Console.Write(ConsoleHelper.CenterText(stack.stackItems[i], stack.MaxLengthItems));
                        }
                    }
                    Console.WriteLine('║');
                }
                ConsoleHelper.DrawSeparator(stack.MaxLengthItems,1, '╚', '╩', '╝');

                Console.WriteLine("\n");
            }
        }
        public void PrintPush()
        {
            ConsoleHelper.ClearScreen();

            PrintStack();

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
                PrintStack();
                var value = stack.Pop();
                Console.WriteLine($"Удалено значение: {value}");
                Console.WriteLine("\n");
                Console.WriteLine("Текущее содержимое стека :");
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
                Console.WriteLine("Текущее содержимое стека :");
                PrintStack();
                var value = stack.Top();
                Console.WriteLine($"Вершина стека: {value}");
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Стек пуст, вершину невозможно отобразить.");
            }

        }

        public void WriteDataFile()
        {
            ConsoleHelper.ClearScreen();

            Console.WriteLine("Введите желаемое количество опреаций в файле.");
            var countOperations = Console.ReadLine();
            BigInteger num;
            bool isNum = BigInteger.TryParse(countOperations, out num);
            if (isNum)
            {
                FileLogic.WriteFile(FileLogic.PathToGeneratedData, num);
            }
            else
            {
                Console.WriteLine("Введенную строку невозможно преобразовать в число");
                return;
            }
        }

        public void ExecuteMeasurements()
        {
            ConsoleHelper.ClearScreen();
            Console.WriteLine("Стек работает, ждите");
            Measurements measurements = new Measurements();
            measurements.ExecuteMeasurements(FileLogic.PathToGeneratedData, FileLogic.PathToMemoryFile, FileLogic.PathToTimeFile);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructure.DynamicStructure.ConsoleUI
{ 
    public class PrintStackLogic
    {
        public DynamicStructure.Core.Stack.Stack<string> stack = new DynamicStructure.Core.Stack.Stack<string>();
        public void PrintStack()
        {
            ConsoleHelper.ClearScreen();
            if (stack.Count <= 0)
            {
                Console.WriteLine("Стек пуст, нечего отображать");
                Console.WriteLine("\n");
                return;
            }
            else
            {
                Console.WriteLine("Содержимое стека :");
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\n");
            }
        }
        public void PushItem()
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

        public void PopItem()
        {
            ConsoleHelper.ClearScreen();
            var value = stack.Pop();
            Console.WriteLine($"Удалено значение: {value}");

            Console.WriteLine("\n");
            Console.WriteLine("Текущее содержимое стека :");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

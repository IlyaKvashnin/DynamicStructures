using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
s
namespace DynamicStructure.DynamicStructure.ConsoleUI
{
    internal class PrintStackLogic
    {
        public DynamicStructure.Core.Stack.Stack<string> stack = new DynamicStructure.Core.Stack.Stack<string>();

        public void PushItem()
        {
            ConsoleHelper.ClearScreen();
            Console.WriteLine("Введите строку или число, которое нужно положить в стек.");
            var value = Console.ReadLine();
            int num;
            bool isNum = int.TryParse(value, out num);
            if (isNum)
                stack.Push(num.ToString());
            else
                stack.Push(value);
            Console.WriteLine($"Pushed {value}");
        }

       // public void PopItem()
        //{
         //   ConsoleHelper.ClearScreen();
          //  stac
           // Console.WriteLine($"Pushed {value}");
       // }
    }
}

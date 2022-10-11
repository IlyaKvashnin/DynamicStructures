using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.Stack;
using System;
using System.Collections;

namespace DynamicStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {

            DynamicStructure.Core.Stack.Stack<string> stack = new DynamicStructure.Core.Stack.Stack<string>();
            for (int i = 0; i <= 5; i++)
            {
                var value = Console.ReadLine();
                int num;
                bool isNum = int.TryParse(value, out num);
                if (isNum)
                    stack.Push(num.ToString());
                else
                    stack.Push(value);

            }

            while (stack.Count > 0)
            {
                stack.Pop();
            }

        }

        
    }
}
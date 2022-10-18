using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructure.DynamicStructure.Core;
using DynamicStructure.DynamicStructure.FileWorker;

namespace DynamicStructure.DynamicStructure.ConsoleUI
{
    public class PostfixNotationLogic
    {
        public static void CalculatePostfixNotation()
        {
            ConsoleHelper.ClearScreen();
            Console.WriteLine("Введите выражение в постфиксной записи: ");
            Console.WriteLine($"Результат вычисления: {PostfixNotation.Counting(Console.ReadLine())}");
        }

        public static void CalculatePostfixNotationFromFile()
        {
            ConsoleHelper.ClearScreen();
            var file = FileLogic.ReadFile("../../../DynamicStructure.Core/Stack/example.txt");
            var str = new string("");
            for (int i = 0; i < file.Count(); i++)
            {
                foreach (var item in file[i])
                {
                    str += item;
                }
                Console.WriteLine($"Строка, содержащаяся в файле : {str}");
                Console.WriteLine($"Результат : {PostfixNotation.Counting(str)}");
                Console.WriteLine("\n");
                str = "";
            }
            
        }

        public static void CalculateInfixNotation()
        {
            ConsoleHelper.ClearScreen();
            Console.WriteLine("Введите выражение в инфиксной записи: ");
            var str = Console.ReadLine();
            Console.WriteLine($"Выражение в постфиксной записи: {PostfixNotation.GetExpression(str)}");
            Console.WriteLine($"Результат: {PostfixNotation.Calculate(str)}");
        }
    }
}

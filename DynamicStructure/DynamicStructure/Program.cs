using DynamicStructure.DynamicStructure.ConsoleUI;
using System;
using DynamicStructure.DynamicStructure.Core.Stack;
using DynamicStructure.DynamicStructure.FileWorker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace DynamicStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {

            MenuLogic mainMenu = new MenuLogic(MainMenu.mainMenu);
            mainMenu.Run();
            //while (true) //Бесконечный цикл
            //{
            //    Console.Write("Введите выражение: "); //Предлагаем ввести выражение
            //    Console.WriteLine(PostfixNotation.Calculate(Console.ReadLine())); //Считываем, и выводим результат
            //}
        }



    }
}
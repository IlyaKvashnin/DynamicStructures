using DynamicStructure.DynamicStructure.ConsoleUI;
using DynamicStructure.DynamicStructure.Core.Queue;
using System;

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